﻿using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Microservice.Transferencias.Wcf
{
    public class SecurityCreatorInspector : IClientMessageInspector
    {
        private readonly string _username;
        private readonly string _password;

        public SecurityCreatorInspector(string username, string password)
        {
            _username = username;
            _password = password;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            request.Headers.Add(new SoapSecurityHeader(_username, _password));
            return null;
        }
    }
}