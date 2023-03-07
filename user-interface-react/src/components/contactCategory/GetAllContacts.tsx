import { useEffect, useState } from "react";
import * as Constants from "../../utilities/Constants"

export default function getAllContacts() {

  function RenderGetAllContacts()  {
    const [contacts, getAllContacts] = useState<any[]>([]);

    useEffect(() => {
      fetch(Constants.CONTACT.GET_ALL, {method: 'GET'})
        .then(response => response.json())
        .then(data => {getAllContacts(data)})
        .catch((err) => console.error(err))
    }, []);

    return (
      <table>
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

  return (
    <section>
      <div>
        <h1>All Contacts</h1>
        {RenderGetAllContacts()}
      </div>
    </section>
  );
}
