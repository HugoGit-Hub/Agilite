using Agilite.UI.Models;
using System.Collections.Generic;

namespace Agilite.UI.ViewModels;

internal class DefaultPageViewModal
{
	private IList<ContactModel> _contacts;

	public DefaultPageViewModal()
	{
		_contacts = new List<ContactModel>
		{
			new ContactModel
			{
				ArchivedContact = false,
				IdContact = 1,
				NameContact = "test contact 1"
			},

			new ContactModel
			{
				ArchivedContact = false,
				IdContact = 2,
				NameContact = "test contact 2"
			},
		
			new ContactModel
			{
				ArchivedContact = false,
				IdContact = 3,
				NameContact = "test contact 3"
			}
		};
	}

    public IList<ContactModel> Contacts
    {
        get { return _contacts; }
        set { _contacts = value; }
    }
}
