import React, { useState } from 'react'

import './Sidebar.scss'
import Arrow from "../assets/icons/arrow_filter.svg"

function Sidebar() {
  const [isSidebarOpen, setSidebarOpen] = useState(false);

  return (
    <div className={`sidebar ${isSidebarOpen ? 'open' : ''}`}>
      <div className="sidebar-container" id="sidebarfirst">
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
            <input id="distance" type="text" />
          </div>
          <div className="input">
            <label htmlFor="sustainability" className="label">Scale of sustainability</label>
            <input id="sustainability" type="text" />
          </div>
          <div className="input">
            <label htmlFor="industry" className="label">Industry</label>
            <input id="industry" type="text" />
          </div>
          <div className="input">
            <label htmlFor="type" className="label">Type</label>
            <div className="button-group">
              <button className="active">Non-Profit</button>
              <button>Profit</button>
            </div>
          </div>
        </div>
      </div>

      <div className="sidebar-pull" onClick={() => setSidebarOpen(!isSidebarOpen)}>
        <span className="label">
          Filter
        </span>
        <span className="icon">
          <img src={Arrow} alt="" />
        </span>
      </div>
    </div>
  )
}

export default Sidebar;
