import React, { Component } from 'react';
import { json } from 'express';

export class FetchData extends Component {
  displayName = FetchData.name

    constructor(props) {
        super(props);
        this.state = {};

    }

    handleChange(e) {
        this.setState({ message: e.target.value });
    }

    handleClick() {
        fetch('api/api', {
                method: 'post',
                headers: { 'Content-Type': 'application/json' },
                body: { "message": this.state.message }
            })
            .then(() => this.setState({ message: null }))
            .catch((err) => console.log(err))
    }

    render() {
    
    return (
      <div>
        <h1>Enter string message</h1>
            <input type="text" value={this.state.message} onChange={this.handleChange.bind(this)}></input>
            <button onClick={this.handleClick.bind(this)}>Send</button>
      </div>
    );
  }
}
