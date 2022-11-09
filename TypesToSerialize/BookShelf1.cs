﻿#if NETCOREAPP3_0_OR_GREATER
using MemoryPack;
#endif
using MessagePack;
using ProtoBuf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SerializerTests.TypesToSerialize
{
    [Serializable, DataContract, ProtoContract, MessagePackObject
#if NETCOREAPP3_0_OR_GREATER
        , MemoryPackable
#endif
    ]
    public partial class BookShelf1
    {
        [DataMember, ProtoMember(1), Key(0)]
        public List<Book1> Books
        {
            get;
            set;
        }

        [DataMember, ProtoMember(2), Key(1)]
        private string Secret;

        public BookShelf1(string secret)
        {
            Secret = secret;
        }
#if NETCOREAPP3_0_OR_GREATER
        [MemoryPackConstructor]
#endif
        public BookShelf1() // Parameterless ctor is needed for every protocol buffer class during deserialization
        { }
    }

    [Serializable, DataContract, ProtoContract, MessagePackObject
#if NETCOREAPP3_0_OR_GREATER
        , MemoryPackable
#endif
    ]
    public partial class Book1
    {
        [DataMember, ProtoMember(1), Key(0)]
        public string Title;

        [DataMember, ProtoMember(2), Key(1)]
        public int Id;
    }
}
