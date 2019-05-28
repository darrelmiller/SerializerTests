﻿#if NETCOREAPP3_0

using SerializerTests.TypesToSerialize;
using SimdJsonSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;

namespace SerializerTests.Serializers
{
    /// <summary>
    /// Was added as part of .NET Core 3.0
    /// </summary>
    /// <typeparam name="T"></typeparam>
    class NetCoreJsonSerializer<T> : TestBase<T, JsonSerializerOptions>
    {
        public NetCoreJsonSerializer(Func<int, T> testData, Action<T> dataToucher) : base(testData, dataToucher)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Serialize(T obj, Stream stream)
        {
            JsonSerializer.WriteAsync(obj, typeof(T), stream).Wait();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override T Deserialize(Stream stream)
        {
            return (T) JsonSerializer.ReadAsync(stream, typeof(T)).Result;
        }
    }
}

#endif
