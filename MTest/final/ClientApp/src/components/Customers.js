import React, { Component } from 'react';
import '../App.css';
// import Information from './Information';
// import InformationUpdate  from './InformationUpdate'
import Add from './AddCustomer';
// import Change from './Change';

export class Customers extends Component {
  constructor(props) {
    super(props);
    this.state = {
      customers: [],
      infa: [],
      indx: 0,
      id: 1,
      name: '',
      mast: '',
      flag: false
    };
    this.onHandleDelete = this.onHandleDelete.bind(this);
    this.onHandleUpdate = this.onHandleUpdate.bind(this);
    this.addCustomer = this.addCustomer.bind(this);
    this.onHandleFlag = this.onHandleFlag.bind(this);
    this.onHandleEdit = this.onHandleEdit.bind(this);
    
  }
  componentDidMount() {
    this.loadData();
  }

   loadData = async() => {
    fetch('http://localhost:5000/api/Customer')
      .then(data => data.json())
      .then((data) => {
        this.setState({ customers: data })
      });
  }

  onHandleDelete = async (remove) => {
    if (remove) {
      return fetch('http://localhost:5000/api/Customer' + '/' + remove.id, {
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
    return fetch('http://localhost:5000/api/Customer/' + this.state.indx, {
      method: 'PUT',
      mode: "cors",
      body: JSON.stringify({
        'cutomer_name': this.state.infa.name,
        'masters': this.state.infa.mast
      }),
      headers: {
        'Content-Type': 'application/json'
      }
    }).then(res => res).then(()=>this.loadData())
  
  }
  onHandleEdit(e, k) {
    var cur = this.state.customers;
    if (k === 1) {
      cur.map((item, i) => {
        if (item.id === this.state.indx) {
          item.name = e.target.value
        }

      })
    }
    if (k === 2) {
      cur.map((item, i) => {
        if (item.id === this.state.indx) {
          item.masters = e.target.value
        }

      })
    }
    
    this.setState({
      customers: cur,
    })

  }
  onHandleUpdate(date) {
    this.setState({
      flag: true,
      infa: date,
      indx: date.id
    })
  }

  addCustomer = async (name, mast) => {
    if (name, mast) {

      fetch("http://localhost:5000/api/Customer", {
        method: "post",
        body: JSON.stringify({
          'customer_name': name,
          'masters': mast
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
          {this.state.customers.map((item, j) => {
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
          <Add onAdd={(name, mast) => this.addCustomer(name, mast)} />
        </div>
      </div>
    )



  };

};

