import React, { Component } from 'react';
import '../App.css';
class AddProduct extends Component{
    constructor(props){
        super(props);
        this.state = {
   
        }
        this.addProduct = this.addProduct.bind(this);
 }
 addProduct(event){
    let cat_id  = this.refs.cat_id.value;
    let from_point = this.refs.from_point.value;
    let to_point = this.refs.to_point.value;
    let seat_num = this.refs.seat_num.value;

     this.props.onAdd(cat_id, from_point, to_point,seat_num);
     this.refs.cat_id.value="";
     this.refs.from_point.value="";
     this.refs.to_point.value="";
     this.refs.seat_num.value="";

 }
 render(){
     return(
        <form className="froms" onSubmit={this.addProduct}>
          <input className="inputName"  placeholder="Category_id:" type="text" ref="cat_id"/>
          <input type="text" className="inputName" placeholder="From point:"  ref="from_point"/>
          <input type="text" className="inputName" placeholder="To point:"  ref="to_point"/>
          <input type="text" className="inputName" placeholder="Seat number:"  ref="seat_num"/>
        <br/>
       <button type ="submit" className="btn1" > Add </button>
     </form>
     );
 }
}
export default AddProduct;