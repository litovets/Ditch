﻿using System.Collections.Generic;
using System.Linq;
using Ditch.Core.Helpers;
using Newtonsoft.Json;

namespace Ditch.Golos.Protocol
{
    /// <summary>
    /// signed_transaction
    /// libraries\protocol\include\golos\protocol\transaction.hpp
    /// </summary>
    [JsonObject(MemberSerialization.OptIn)]
    public class SignedTransaction : Transaction
    {
        #region for json

        [JsonProperty("operations")]
        public object[][] Operations
        {
            get
            {
                var buf = new object[BaseOperations.Length][];
                for (var i = 0; i < BaseOperations.Length; i++)
                {
                    var op = BaseOperations[i];
                    buf[i] = new object[] { op.TypeName, op };
                }
                return buf;
            }
        }

        /// <summary>
        /// API name: signatures
        /// 
        /// </summary>
        /// <returns>API type: signature_type (typedef fc::array&lt;unsigned char, 65> compact_signature;)</returns>
        public List<byte[]> Signatures { get; set; } = new List<byte[]>();

        #endregion for json


        [JsonProperty("signatures")]
        public string[] SignaturesStr => Signatures.Select(Hex.ToString).ToArray();
    }
}