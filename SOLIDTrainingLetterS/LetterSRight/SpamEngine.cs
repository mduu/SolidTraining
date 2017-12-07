using System;
using System.Collections.Generic;
using System.Text;

namespace LetterSRight
{
    internal interface ISpamEngine
    {
        void Process();
    }

    class SpamEngine : ISpamEngine
    {
        private readonly IFeedback _feedback;
        private readonly IEmailRepository _repository;
        private readonly IEmailaddressValidator _validtor;
        private readonly IEmailSender _sender;

        public SpamEngine(
            IFeedback feedback,
            IEmailRepository repository,
            IEmailaddressValidator validtor,
            IEmailSender sender)
        {
            _feedback = feedback ?? throw new ArgumentNullException(nameof(feedback));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _validtor = validtor ?? throw new ArgumentNullException(nameof(validtor));
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        public void Process()
        {
            foreach (var recipientAddress in _repository.ReadEmailAddresses())
            {
                if (_validtor.Validate(recipientAddress))
                {
                    _sender.SendMailTo(recipientAddress);
                }
            }
        }
    }

}
