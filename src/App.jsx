import React from 'react';
import Modal from 'react-modal';

import { Sidebar, SearchBox, SubmitBusinessForm } from './components';

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
  const [ submitBusinessModelIsOpen ,setSubmitBusinessModalOpen ] = React.useState(false);

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
            <SubmitBusinessForm />
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
