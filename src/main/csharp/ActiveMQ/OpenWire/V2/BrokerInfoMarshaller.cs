/** Licensed to the Apache Software Foundation (ASF) under one or more* contributor license agreements.  See the NOTICE file distributed with* this work for additional information regarding copyright ownership.* The ASF licenses this file to You under the Apache License, Version 2.0* (the "License"); you may not use this file except in compliance with* the License.  You may obtain a copy of the License at**     http://www.apache.org/licenses/LICENSE-2.0** Unless required by applicable law or agreed to in writing, software* distributed under the License is distributed on an "AS IS" BASIS,* WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.* See the License for the specific language governing permissions and* limitations under the License.*///// NOTE!: This file is autogenerated - do not modify!//        if you need to make a change, please see the Groovy scripts in the//        activemq-core module//using System;using System.Collections;using System.IO;using ActiveMQ.Commands;using ActiveMQ.OpenWire;using ActiveMQ.OpenWire.V2;namespace ActiveMQ.OpenWire.V2{  /// <summary>  ///  Marshalling code for Open Wire Format for BrokerInfo  /// </summary>  class BrokerInfoMarshaller : BaseCommandMarshaller  {    public override DataStructure CreateObject()     {        return new BrokerInfo();    }    public override byte GetDataStructureType()     {        return BrokerInfo.ID_BrokerInfo;    }    //     // Un-marshal an object instance from the data input stream    //     public override void TightUnmarshal(OpenWireFormat wireFormat, Object o, BinaryReader dataIn, BooleanStream bs)     {        base.TightUnmarshal(wireFormat, o, dataIn, bs);        BrokerInfo info = (BrokerInfo)o;        info.BrokerId = (BrokerId) TightUnmarshalCachedObject(wireFormat, dataIn, bs);        info.BrokerURL = TightUnmarshalString(dataIn, bs);        if (bs.ReadBoolean()) {            short size = dataIn.ReadInt16();            BrokerInfo[] value = new BrokerInfo[size];            for( int i=0; i < size; i++ ) {                value[i] = (BrokerInfo) TightUnmarshalNestedObject(wireFormat,dataIn, bs);            }            info.PeerBrokerInfos = value;        }        else {            info.PeerBrokerInfos = null;        }        info.BrokerName = TightUnmarshalString(dataIn, bs);        info.SlaveBroker = bs.ReadBoolean();        info.MasterBroker = bs.ReadBoolean();        info.FaultTolerantConfiguration = bs.ReadBoolean();    }    //    // Write the booleans that this object uses to a BooleanStream    //    public override int TightMarshal1(OpenWireFormat wireFormat, Object o, BooleanStream bs) {        BrokerInfo info = (BrokerInfo)o;        int rc = base.TightMarshal1(wireFormat, info, bs);        rc += TightMarshalCachedObject1(wireFormat, (DataStructure)info.BrokerId, bs);        rc += TightMarshalString1(info.BrokerURL, bs);        rc += TightMarshalObjectArray1(wireFormat, info.PeerBrokerInfos, bs);        rc += TightMarshalString1(info.BrokerName, bs);        bs.WriteBoolean(info.SlaveBroker);        bs.WriteBoolean(info.MasterBroker);        bs.WriteBoolean(info.FaultTolerantConfiguration);        return rc + 0;    }    //     // Write a object instance to data output stream    //    public override void TightMarshal2(OpenWireFormat wireFormat, Object o, BinaryWriter dataOut, BooleanStream bs) {        base.TightMarshal2(wireFormat, o, dataOut, bs);        BrokerInfo info = (BrokerInfo)o;        TightMarshalCachedObject2(wireFormat, (DataStructure)info.BrokerId, dataOut, bs);        TightMarshalString2(info.BrokerURL, dataOut, bs);        TightMarshalObjectArray2(wireFormat, info.PeerBrokerInfos, dataOut, bs);        TightMarshalString2(info.BrokerName, dataOut, bs);        bs.ReadBoolean();        bs.ReadBoolean();        bs.ReadBoolean();    }    //     // Un-marshal an object instance from the data input stream    //     public override void LooseUnmarshal(OpenWireFormat wireFormat, Object o, BinaryReader dataIn)     {        base.LooseUnmarshal(wireFormat, o, dataIn);        BrokerInfo info = (BrokerInfo)o;        info.BrokerId = (BrokerId) LooseUnmarshalCachedObject(wireFormat, dataIn);        info.BrokerURL = LooseUnmarshalString(dataIn);        if (dataIn.ReadBoolean()) {            short size = dataIn.ReadInt16();            BrokerInfo[] value = new BrokerInfo[size];            for( int i=0; i < size; i++ ) {                value[i] = (BrokerInfo) LooseUnmarshalNestedObject(wireFormat,dataIn);            }            info.PeerBrokerInfos = value;        }        else {            info.PeerBrokerInfos = null;        }        info.BrokerName = LooseUnmarshalString(dataIn);        info.SlaveBroker = dataIn.ReadBoolean();        info.MasterBroker = dataIn.ReadBoolean();        info.FaultTolerantConfiguration = dataIn.ReadBoolean();    }    //     // Write a object instance to data output stream    //    public override void LooseMarshal(OpenWireFormat wireFormat, Object o, BinaryWriter dataOut) {        BrokerInfo info = (BrokerInfo)o;        base.LooseMarshal(wireFormat, o, dataOut);        LooseMarshalCachedObject(wireFormat, (DataStructure)info.BrokerId, dataOut);        LooseMarshalString(info.BrokerURL, dataOut);        LooseMarshalObjectArray(wireFormat, info.PeerBrokerInfos, dataOut);        LooseMarshalString(info.BrokerName, dataOut);        dataOut.Write(info.SlaveBroker);        dataOut.Write(info.MasterBroker);        dataOut.Write(info.FaultTolerantConfiguration);    }      }}