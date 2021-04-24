import React from 'react';

const SubmitBusinessForm = () => {
  return (
    <div>
      <form>
        <div className="heading">
          <span className="label">Add a business</span>
        </div>

        <div>
          <div className="input">
            <label htmlFor="name" className="label">Name</label>
            <input id="name" type="text" />
          </div>
          <div className="input">
            <label htmlFor="address" className="label">Address</label>
            <input id="address" type="text" />
          </div>
          <div className="input">
            <label htmlFor="industry" className="label">Industry</label>
            <input id="industry" type="text" />
          </div>
          <div className="input">
            <label htmlFor="country" className="label">Country</label>
            <input id="country" type="text" />
          </div>
          <div className="input">
            <label htmlFor="logo" className="label">Upload your logo</label>
            <input id="logo" type="text" />
          </div>
          <div className="input">
            <label htmlFor="mission" className="label">Mission statement</label>
            <input id="mission" type="text" />
          </div>
        </div>

        <button type="submit">Submit</button>
      </form>
    </div>
  );
};

export default SubmitBusinessForm;