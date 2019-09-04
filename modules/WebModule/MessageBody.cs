// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Newtonsoft.Json;

namespace WebModule
{
    public class MessageBody
    {
        [JsonProperty("message")]
        public string Message { get; set; }
        [JsonProperty("deviceId")]
        public string DeviceId { get; set; }
        [JsonProperty("timeCreated")]
        public string TimeCreated { get; set; }
    }

}