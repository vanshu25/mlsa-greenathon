
import {AzureMap, AzureMapsProvider} from 'react-azure-maps'
import {AuthenticationType} from 'azure-maps-control'
import './App.scss';
import Sidebar from './components/Sidebar';

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
          <Sidebar/>
          <div className="search-box">
            <input type="text" name="searchBox" id="searchBox" placeholder="Search a business..."/>
          </div>
        
          <div className="fab-overlay">
            <button className="fab">Add a new business</button>
          </div>
        </div>
      </AzureMapsProvider>

    </div>
  );
}

export default App;
