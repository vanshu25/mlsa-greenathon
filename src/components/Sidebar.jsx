import React, { useState } from 'react'
import '../assests/css/Sidebar.scss'
import Arrow from "../assests/icons/arrow_filter.svg"

function Sidebar() {
    const [sidebarState,setSidebarState]=useState("open")
    return (
            <div className="sidebar open">
            <div className="first" id="sidebarfirst">
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
                        <div className="button-group">
                        <button className="active">Non-Profit</button>
                        <button>Profit</button>
                        </div>
                    </div>
                </div>
            </div>
            <div className="second" id="sidebarsec"onClick={()=>{
                if(sidebarState=="open"){
                document.getElementById("sidebarfirst").classList.remove("first")
                document.getElementById("sidebarfirst").classList.add("first-close")
                document.getElementById("sidebarsec").classList.remove("second")
                document.getElementById("sidebarsec").classList.add("second-close")
                setSidebarState("close")
                }else{
                    document.getElementById("sidebarfirst").classList.remove("first-close")
                    document.getElementById("sidebarfirst").classList.add("first")
                    document.getElementById("sidebarsec").classList.remove("second-close")
                    document.getElementById("sidebarsec").classList.add("second")
                    setSidebarState("open")
                }

            }}>
                <div className="filterfirst">
                        FILTER
                    </div>
                <div className="filtersec">
                   <img src={Arrow}/>
                </div>
                
            </div>
          </div>
    )
}

export default Sidebar
