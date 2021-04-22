import './App.scss';

const App = () => {
  return (
    <div className="App">
      <div className="sidebar">
        <div className="heading">
          <span className="label">Sort and filter</span>
        </div>

        <div>
          <div className="input">
            <label htmlFor="sortBy" className="label">Sort by</label>
            <select name="sortBy" id="sortBy"></select>
          </div>
          <div className="input">
            <label htmlFor="distance" className="label">Distance</label>
            <input id="distance" type="text"/>
          </div>
          <div className="input">
            <label htmlFor="sustainability" className="label">Scale of sustainability</label>
            <input id="sustainability" type="text"/>
          </div>
          <div className="input">
            <label htmlFor="industry" className="label">Industry</label>
            <input id="industry" type="text"/>
          </div>
          <div className="input">
            <label htmlFor="type" className="label">Type</label>
            <input id="type" type="text"/>
          </div>
        </div>
      </div>
    
      <div className="fab-overlay">
        <button className="fab">Add a new business</button>
      </div>

    </div>
  );
}

export default App;
