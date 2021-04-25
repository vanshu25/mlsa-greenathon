import React, { useEffect, useState } from 'react';
import Modal from 'react-modal';

import { Sidebar, SearchBox, SubmitBusinessForm, ModalCloseButton } from './components';
import { queryBusiness, submitBusiness } from './services/api';

import { AzureMap, AzureMapsProvider } from 'react-azure-maps'
import { AuthenticationType } from 'azure-maps-control'

import './App.scss';

const azureMapOptions = {
  authOptions: {
    authType: AuthenticationType.subscriptionKey,
    subscriptionKey: 'Ea_uzBbOhHmVPM5UjV-vEoW7wRw0bO-RTc7bo7AhtIw'
  },
}

Modal.setAppElement('#root');

const App = () => {
  const [submitBusinessModelIsOpen, setSubmitBusinessModalOpen] = useState(false);
  const closeModal = () => setSubmitBusinessModalOpen(false);

  const [businesses, setBusinesses] = useState([]);

  useEffect(() => {
    queryBusiness()
      .then(x => setBusinesses(x));
  }, []);

  const handleSubmitBusiness = (values) => {
    console.log(values)
    submitBusiness(values);
  }

  return (
    <div className="App">
      <AzureMapsProvider>
        <div>
          <div className="map-container">
            <AzureMap options={azureMapOptions} />
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
