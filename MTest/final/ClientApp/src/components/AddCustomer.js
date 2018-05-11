import React, { Component } from 'react';
import '../App.css';
class AddCustomer extends Component{
    constructor(props){
        super(props);
        this.state = {
   
        }
        this.addCustomer = this.addCustomer.bind(this);
 }
 addCustomer(event){
    let name  = this.refs.name.value;
    let mast = this.refs.mast.value;

     this.props.onAdd(name,mast);
     this.refs.name.value="";
     this.refs.mast.value="";

 }
 render(){
     return(
        <form className="froms" onSubmit={this.addCustomer}>
          <input className="inputName"  placeholder="Customer name:" type="text" ref="name"/>
          <input type="text" className="inputName" placeholder="Masters:"  ref="mast"/>
        <br/>
       <button type ="submit" className="btn1" > Add </button>
     </form>
     );
 }
}
export default AddCustomer;