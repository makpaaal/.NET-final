import React, { Component } from 'react';
import { Customers } from './components/Customers';
import { Products } from './components/Products';
import './App.css';
import {
  Route,
  NavLink,
  HashRouter
} from "react-router-dom";


export default class App extends Component {
  displayName = App.name

  render() {
    return (
      <HashRouter>      
      <div className="App">
        <ul className="header">
          <li><NavLink exact to='/Customer'>Registration</NavLink></li> 
          <li><NavLink exact to='/Product'>OrderTicket</NavLink></li> 
        </ul>
       <div className="content">
       <Route exact path='/Customer' render={(props) => (
        <Customers {...props}  />
       )}/>
       <Route exact path='/Product' render={(props) => (
        <Products {...props}/>
       )}/>

       </div>
     </div>
    </HashRouter>
      
    );
  }
}
