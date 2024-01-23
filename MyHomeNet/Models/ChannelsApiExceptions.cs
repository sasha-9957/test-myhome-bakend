using System;

public class ChannelsApiExceptions
    {
        public class ChannelsApiException : Exception
        {
            public string Code { get; }

            protected ChannelsApiException(string code, string message = null, Exception inner = null)
                : base(message ?? code, inner)
            {
                Code = code;
            }
        }

        public class ChannelAlreadyExistsException : ChannelsApiException
        {
            public ChannelAlreadyExistsException()
                : base("CHANNEL_ALREADY_EXISTS")
            { }
        }

        public class HostNotSupportedException : ChannelsApiException
        {
            public HostNotSupportedException()
                : base("HOST_NOT_SUPPORTED")
            { }
        }
        
        public class HistoryNotSupportedException : ChannelsApiException
        {
            public HistoryNotSupportedException()
                : base("HISTORY_NOT_SUPPORTED")
            { }
        }

        public class HistoryAlreadyRunningException : ChannelsApiException
        {
            public HistoryAlreadyRunningException()
                : base("HISTORY_ALREADY_RUNNING")
            { }
        }

        public class NoIntegrationsException : ChannelsApiException
        {
            public NoIntegrationsException(string message)
                : base("NO_INTEGRATIONS", message)
            { }
        }

        public class ChannelAlreadyDeletedException : ChannelsApiException
        {
            public ChannelAlreadyDeletedException()
                : base("CHANNEL_ALREADY_DELETED")
            { }
        }

        public class PoorIntegrationException : ChannelsApiException
        {
            public PoorIntegrationException(string message)
                : base("POOR_INTEGRATION", message)
            { }
        }

        public class InvalidUrlException : ChannelsApiException
        {
            public InvalidUrlException(string message)
                : base("INVALID_URL", message)
            { }
        }

        public class ArgumentNullException : ChannelsApiException
        {
            public ArgumentNullException(string name)
                : base("ARGUMENT_NULL", name)
            { }
        }
        
        public class AbuseChannelsQuotaException : ChannelsApiException
        {
            public AbuseChannelsQuotaException(int count)
                : base("ABUSE_QUOTA", $"{count}")
            { }
        }
    }