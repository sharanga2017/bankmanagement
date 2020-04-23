using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankManagement.Models
{
    public class MockRecipientRepository : IRecipientRepository
    {
        List<Recipient> _listRecipients { get; set; }
        public IMapper _mapper { get; }

        public MockRecipientRepository(IMapper mapper)
        {
             _listRecipients = new List<Recipient>();
            _mapper = mapper;
        }
        public Recipient Add(Recipient recipient)
        {
            recipient.Id = _listRecipients.Max(e => e.Id) + 1;
            _listRecipients.Add(recipient);
            return recipient;
        }

        public Recipient Delete(int id)
        {
            Recipient recipient = _listRecipients.FirstOrDefault(e => e.Id == id);
            if (recipient != null)
            {
                _listRecipients.Remove(recipient);
            }
            return recipient;
        }

        public IEnumerable<Recipient> GetAllRecipients()
        {
            return _listRecipients;
        }

        public IEnumerable<Recipient> GetRecipientsByUserId(string id)
        {
            return _listRecipients;
        }

        public Recipient Update(Recipient recipientChanges)
        {
            Recipient NewRecipient = recipientChanges;
            Recipient recipient = _listRecipients.FirstOrDefault(e => e.Id == recipientChanges.Id);
            if (recipient != null)
            {
                recipient = _mapper.Map<Recipient>(recipientChanges);

            }
            return recipient;
        }

        public Recipient GetRecipient(int Id)
        {
            return _listRecipients.FirstOrDefault(e => e.Id == Id);
        }
    }
}
