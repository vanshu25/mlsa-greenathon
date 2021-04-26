import React, { useEffect, useState } from 'react';
import Modal from 'react-modal';

import { Sidebar, SearchBox, SubmitBusinessForm, ModalCloseButton } from './components';
import { queryBusiness, submitBusiness } from './services/api';

import { AzureMap, AzureMapFeature, AzureMapsProvider, AzureMapDataSourceProvider, AzureMapLayerProvider } from 'react-azure-maps';
import { AuthenticationType, data } from 'azure-maps-control';

import './App.scss';

const azureMapOptions = {
  authOptions: {
    authType: AuthenticationType.subscriptionKey,
    subscriptionKey: 'Ea_uzBbOhHmVPM5UjV-vEoW7wRw0bO-RTc7bo7AhtIw'
  },
}

Modal.setAppElement('#root');

const App = () => {
  // Modal
  const [submitBusinessModelIsOpen, setSubmitBusinessModalOpen] = useState(false);
  const closeModal = () => setSubmitBusinessModalOpen(false);
  
  // Map configuration
  const [markersLayer] = useState('SymbolLayer');

  // Businesses
  const [businesses, setBusinesses] = useState([]);

  useEffect(() => {
    queryBusiness()
      .then(x => {
        var collection = x.data.map(z => ({
          position: new data.Position(z.longitude, z.latitude)
        }))

        setBusinesses(collection);
      });
  }, []);

  const handleSubmitBusiness = (values) => {
    submitBusiness(values)
      .then(() => {
        alert('Thanks for submitting your business. Your business will be displayed on the map once it has been approved by the website owners.');
        closeModal();
      })
      .catch(err => alert(err));
  }

  return (
    <div className="App">
      <AzureMapsProvider>
        <div>
          <div className="map-container">
            <AzureMap options={azureMapOptions}>
              <AzureMapDataSourceProvider id={'markers AzureMapDataSourceProvider'} options={{ cluster: true, clusterRadius: 2 }}>
                <AzureMapLayerProvider
                  id={'markers AzureMapLayerProvider'}
                  type={markersLayer}/>

                {businesses.map(x => <AzureMapFeature id={'1'} type="Point" properties={{title: 'Pin'}} coordinate={x.position} />)}
              </AzureMapDataSourceProvider>
            </AzureMap>
          </div>
          <Sidebar />
          <SearchBox />

          <Modal className="modal"
            isOpen={submitBusinessModelIsOpen}
            shouldCloseOnOverlayClick={true}
            shouldCloseOnEsc={true}>
            <SubmitBusinessForm onSubmitForm={handleSubmitBusiness} />
            <ModalCloseButton onModalClose={closeModal} />
          </Modal>
        
          <div className="fab-overlay">
            <button className="fab" onClick={() => setSubmitBusinessModalOpen(true)}>Add a new business</button>
          </div>
        </div>
      </AzureMapsProvider>

    </div>
  );
}

export default App;
