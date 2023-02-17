import React, { useState } from "react";
import * as Constants from "../../utilities/Constants"

export default function getAllContacts() {
  // eslint-disable-next-line react-hooks/rules-of-hooks
  const [contacts, getAllContacts] = useState([]);

  function ComponentDidMount() {
    fetch(Constants.CONTACT.GET_ALL, {method: 'GET'})
    .then(response => response.json())
    .then(data => {getAllContacts(data)});
  }

  return (
    <section className="section">
      <div className="container">
        <h1 className="title">All Contacts</h1>
        {RenderGetAllContacts()}
        {ComponentDidMount()}
      </div>
    </section>
  );

  function RenderGetAllContacts()  {
    return (
      <table className="table">
        <thead>
          <tr>
            <th>Id</th>
            <th>Name</th>
            <th>Archived</th>
          </tr>
        </thead>
        <tbody>
          {contacts.map((contact) => (
            <tr key={contact.idContact}>
              <th>{contact.idContact}</th>
              <th>{contact.nameContact}</th>
              <th>{contact.archivedContact}</th>
            </tr>
          ))}
        </tbody>
      </table>
    );
  }
}