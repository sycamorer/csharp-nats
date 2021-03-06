﻿// Copyright 2015 Apcera Inc. All rights reserved.

namespace NATS.Client
{
    /// <summary>
    /// Creates a connection to the NATS server.
    /// </summary>
    public sealed class ConnectionFactory
    {
        /// <summary>
        /// Creates a connection factory to the NATS server.
        /// </summary>
        public ConnectionFactory() { }

        /// <summary>
        /// CreateConnection will attempt to connect to the NATS server.
        /// The url can contain username/password semantics.
        /// Comma seperated arrays are also supported, e.g. urlA, urlB.
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>A new connection to the NATS server</returns>
        public IConnection CreateConnection(string url)
        {
            Options opts = new Options();
            opts.processUrlString(url);
            return CreateConnection(opts);
        }

        /// <summary>
        /// Retrieves the default set ot client options.
        /// </summary>
        public static Options GetDefaultOptions()
        {
            return new Options();
        }

        /// <summary>
        /// CreateSecureConnection will attempt to connect to the NATS server using TLS.
        /// The url can contain username/password semantics.
        /// </summary>
        /// <param name="url">connect url</param>
        /// <returns>A new connection to the NATS server</returns>
        public IConnection CreateSecureConnection(string url)
        {
            Options opts = new Options();
            opts.processUrlString(url);
            opts.Secure = true;
            return CreateConnection(opts);
        }

        /// <summary>
        /// Create a connection to the NATs server using default options.
        /// </summary>
        /// <returns>A new connection to the NATS server</returns>
        public IConnection CreateConnection()
        {
            return CreateConnection(new Options());
        }

        /// <summary>
        /// CreateConnection to the NATs server using the provided options.
        /// </summary>
        /// <param name="opts">NATs client options</param>
        /// <returns>A new connection to the NATS server</returns>
        public IConnection CreateConnection(Options opts)
        {
            Connection nc = new Connection(opts);
            nc.connect();
            return nc;
        }

        /// <summary>
        /// Create an encoded connection to the NATs server using default options.
        /// </summary>
        /// <returns>A new connection to the NATS server</returns>
        public IEncodedConnection CreateEncodedConnection()
        {
            return CreateEncodedConnection(new Options());
        }

        /// <summary>
        /// CreateEncodeedConnection will attempt to connect to the NATS server.
        /// The url can contain username/password semantics.
        /// </summary>
        /// <param name="url">The url</param>
        /// <returns>A new connection to the NATS server</returns>
        public IEncodedConnection CreateEncodedConnection(string url)
        {
            Options opts = new Options();
            opts.Url = url;
            return CreateEncodedConnection(opts);
        }

        /// <summary>
        /// CreateEncodedConnection to the NATs server using the provided options.
        /// </summary>
        /// <param name="opts">NATs client options</param>
        /// <returns>A new connection to the NATS server</returns>
        public IEncodedConnection CreateEncodedConnection(Options opts)
        {
            EncodedConnection nc = new EncodedConnection(opts);
            nc.connect();
            return nc;
        }
    }
}
