import {AzureMap, AzureMapsProvider} from 'react-azure-maps'
import {AuthenticationType} from 'azure-maps-control'
import './App.scss';
import { Sidebar, SearchBox } from './components';

const azureMapOptions = {
  authOptions: {
      authType: AuthenticationType.subscriptionKey,
      subscriptionKey: 'Ea_uzBbOhHmVPM5UjV-vEoW7wRw0bO-RTc7bo7AhtIw'
  },
}

const App = () => {
  return (
    <div className="App">
      <AzureMapsProvider>
        <div>
          <div className="map-container">
            <AzureMap options={azureMapOptions} />
          </div>
          <Sidebar />
          <SearchBox />
        
          <div className="fab-overlay">
            <button className="fab">Add a new business</button>
          </div>
        </div>
      </AzureMapsProvider>

    </div>
  );
}

export default App;
