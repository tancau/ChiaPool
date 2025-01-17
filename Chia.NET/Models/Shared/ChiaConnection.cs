﻿using System.Net;
using System.Text.Json.Serialization;

namespace Chia.NET.Models
{
    public class ChiaConnection
    {
        [JsonPropertyName("node_id")]
        public string NodeId { get; init; }

        [JsonPropertyName("bytes_read")]
        public int BytesRead { get; init; }

        [JsonPropertyName("bytes_written")]
        public int BytesWritten { get; init; }

        [JsonPropertyName("peer_host")]
        public IPAddress PeerHost { get; init; }

        [JsonPropertyName("peer_port")]
        public short PeerPort { get; init; }

        [JsonPropertyName("peer_server_port")]
        public short PeerServerPort { get; init; }

        [JsonPropertyName("local_port")]
        public short LocalPort { get; init; }

        [JsonPropertyName("type")]
        public int Type { get; init; }

        [JsonConstructor]
        public ChiaConnection()
        {
        }
    }
}
