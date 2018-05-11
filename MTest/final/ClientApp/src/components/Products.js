import React, { Component } from 'react';
import '../App.css';
// import Information from './Information';
// import InformationUpdate  from './InformationUpdate'
import Add from './AddProduct';
// import Change from './Change';

export class Products extends Component {
  constructor(props) {
    super(props);
    this.state = {
      products: [],
      infa: [],
      indx: 0,
      id: 1,
      cat_id: '',
      from_point: '',
      to_point: '',
      seat_num: '',
      flag: false
    };
    this.onHandleDelete = this.onHandleDelete.bind(this);
    this.onHandleUpdate = this.onHandleUpdate.bind(this);
    this.addProduct = this.addProduct.bind(this);
    this.onHandleFlag = this.onHandleFlag.bind(this);
    this.onHandleEdit = this.onHandleEdit.bind(this);
    
  }
  componentDidMount() {
    this.loadData();
  }

   loadData = async() => {
    fetch('http://localhost:5000/api/Product')
      .then(data => data.json())
      .then((data) => {
        this.setState({ products: data })
      });
  }

  onHandleDelete = async (remove) => {
    if (remove) {
      return fetch('http://localhost:5000/api/Product' + '/' + remove.id, {
        method: 'delete',
        headers: {
          'Content-Type': 'application/json'
        },
      }).then(res => res).then(()=>this.loadData())
      
      
      
    }
  }
  onHandleFlag() {
    this.setState({
      flag: false
    })
    return fetch('http://localhost:5000/api/Product/' + this.state.indx, {
      method: 'PUT',
      mode: "cors",
      body: JSON.stringify({
        'category_id': this.state.infa.cat_id,
        'fromPoint': this.state.infa.from_point,
        'toPoint': this.state.infa.to_point,
        "seatNumber": this.state.infa.seat_num
      }),
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(res => res).then(()=>this.loadData())
  
  }
  onHandleEdit(e, k) {
    var cur = this.state.products;
    if (k === 1) {
      cur.map((item, i) => {
        if (item.id === this.state.indx) {
          item.cat_id = e.target.value
        }

      })
    }
    if (k === 2) {
      cur.map((item, i) => {
        if (item.id === this.state.indx) {
          item.from_point = e.target.value
        }

      })
    }
    if (k === 3) {
      cur.map((item, i) => {
        if (item.id === this.state.indx) {
          item.to_point = e.target.value
        }

      })
    }
    if (k === 4) {
      cur.map((item, i) => {
        if (item.id === this.state.indx) {
          item.seat_num = e.target.value
        }

      })
    }
    
    this.setState({
      products: cur,
    })

  }
  onHandleUpdate(date) {
    this.setState({
      flag: true,
      infa: date,
      indx: date.id
    })
  }

  addProduct = async (cat_id, from_point, to_point, seat_num) => {
    if (cat_id, from_point, to_point, seat_num) {

      fetch("http://localhost:5000/api/Product", {
        method: "post",
        body: JSON.stringify({
          'category_id': cat_id,
          'fromPoint': from_point,
          'toPoint': to_point,
          "seatNumber": seat_num
        }),
        headers: {
          'Content-Type': 'application/json'
        },
      }).then(res => res.json()).then(()=>this.loadData())
    

    }
    
  }

  render() {
    return (
      <div className="col-md-12">
        <div className="col-md-4">
          {this.state.products.map((item, j) => {
            return (
              <div >
              {/* <Information key={j} info={item} onDelete={(remove) => this.onHandleDelete(remove)} />
              <InformationUpdate key={j} info={item} onUpdate={(date) => this.onHandleUpdate(date)} /> */}
            </div>
            )
          })}
        </div>
        <div className="col-md-4">
          {/* <Change value={this.state.flag} val={this.state.infa} handleEdit={(e, k) => this.onHandleEdit(e, k)} onFlag={this.onHandleFlag} /> */}
        </div>
        <div className="col-md-4">
          <Add onAdd={(cat_id, from_point, to_point, seat_num) => this.addpProduct(cat_id, from_point, to_point, seat_num)} />
        </div>
      </div>
    )



  };

};

