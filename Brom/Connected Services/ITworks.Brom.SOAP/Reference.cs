//------------------------------------------------------------------------------
// <автоматически создаваемое>
//     Этот код создан программой.
//     //
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторного создания кода.
// </автоматически создаваемое>
//------------------------------------------------------------------------------

namespace ITworks.Brom.SOAP
{
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(Namespace="https://brom.itworks.group", ConfigurationName="ITworks.Brom.SOAP.brom_apiPortType")]
    public interface brom_apiPortType
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:DebugPing", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<string> DebugPingAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:DebugEcho", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ValueBase> DebugEchoAsync(ITworks.Brom.SOAP.ValueBase param);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:GetSystemInfo", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ValueStruct> GetSystemInfoAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:GetMetadata", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetMetadataResponse> GetMetadataAsync(ITworks.Brom.SOAP.GetMetadataRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:GetMetadaChildrenNames", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ValueMap> GetMetadaChildrenNamesAsync(string parents);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:GetObject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetObjectResponse> GetObjectAsync(ITworks.Brom.SOAP.GetObjectRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:PostObject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.PostObjectResponse> PostObjectAsync(ITworks.Brom.SOAP.PostObjectRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:DeleteObject", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.DeleteObjectResponse> DeleteObjectAsync(ITworks.Brom.SOAP.DeleteObjectRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:GetObjectList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetObjectListResponse> GetObjectListAsync(ITworks.Brom.SOAP.GetObjectListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:GetSessionParameter", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        [return: System.ServiceModel.MessageParameterAttribute(Name="return")]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ValueBase> GetSessionParameterAsync(string name);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:GetConstant", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetConstantResponse> GetConstantAsync(ITworks.Brom.SOAP.GetConstantRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:SetConstant", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.SetConstantResponse> SetConstantAsync(ITworks.Brom.SOAP.SetConstantRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:GetConstantList", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetConstantListResponse> GetConstantListAsync(ITworks.Brom.SOAP.GetConstantListRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:ExecuteRequest", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteRequestResponse> ExecuteRequestAsync(ITworks.Brom.SOAP.ExecuteRequestRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:ExecuteRequestBatch", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteRequestBatchResponse> ExecuteRequestBatchAsync(ITworks.Brom.SOAP.ExecuteRequestBatchRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:ExecuteMethod", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteMethodResponse> ExecuteMethodAsync(ITworks.Brom.SOAP.ExecuteMethodRequest request);
        
        [System.ServiceModel.OperationContractAttribute(Action="https://brom.itworks.group#brom_api:ExecuteCode", ReplyAction="*")]
        [System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults=true)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteCodeResponse> ExecuteCodeAsync(ITworks.Brom.SOAP.ExecuteCodeRequest request);
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueTypeDescription))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueSystemEnum))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueDocumentWriteMode))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueDocumentPostingMode))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueAccumulationRecordType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueAccountingRecordType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueAccountType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueStorage))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueSimple))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueString))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueNumber))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueDate))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueBoolean))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueStructured))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueStruct))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueRef))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueObjectRef))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueEnumRef))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValuePointInTime))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueNull))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueNonserializable))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueMap))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueKeyValue))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueGuid))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueDataSet))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueTree))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueTable))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueDBNull))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueBoundary))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueBinaryData))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueArray))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public abstract partial class ValueBase
    {
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class RequestParameter
    {
        
        private ValueBase valueField;
        
        private string keyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public ValueBase Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ExecuteRequest_Settings
    {
        
        private RequestField[] fieldField;
        
        private RequestFilter[] filterField;
        
        private RequestSort[] sortField;
        
        private RequestParameter[] parameterField;
        
        private string queryResultIterationField;
        
        private bool includeTemporalDataField;
        
        private bool includeTemporalDataFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Field", Order=0)]
        public RequestField[] Field
        {
            get
            {
                return this.fieldField;
            }
            set
            {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Filter", Order=1)]
        public RequestFilter[] Filter
        {
            get
            {
                return this.filterField;
            }
            set
            {
                this.filterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Sort", Order=2)]
        public RequestSort[] Sort
        {
            get
            {
                return this.sortField;
            }
            set
            {
                this.sortField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Parameter", Order=3)]
        public RequestParameter[] Parameter
        {
            get
            {
                return this.parameterField;
            }
            set
            {
                this.parameterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string QueryResultIteration
        {
            get
            {
                return this.queryResultIterationField;
            }
            set
            {
                this.queryResultIterationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IncludeTemporalData
        {
            get
            {
                return this.includeTemporalDataField;
            }
            set
            {
                this.includeTemporalDataField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IncludeTemporalDataSpecified
        {
            get
            {
                return this.includeTemporalDataFieldSpecified;
            }
            set
            {
                this.includeTemporalDataFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class RequestField
    {
        
        private string keyField;
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class RequestFilter
    {
        
        private ValueBase valueField;
        
        private string keyField;
        
        private string comparisonTypeField;
        
        public RequestFilter()
        {
            this.comparisonTypeField = "Equal";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ValueBase Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("Equal")]
        public string ComparisonType
        {
            get
            {
                return this.comparisonTypeField;
            }
            set
            {
                this.comparisonTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class RequestSort
    {
        
        private string keyField;
        
        private string directionField;
        
        public RequestSort()
        {
            this.directionField = "Asc";
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute("Asc")]
        public string Direction
        {
            get
            {
                return this.directionField;
            }
            set
            {
                this.directionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class GetConstant_Settings
    {
        
        private RequestField[] fieldField;
        
        private string propertiesHierarchyTypeField;
        
        private bool addSkippedPropertiesField;
        
        private bool addSkippedPropertiesFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Field", Order=0)]
        public RequestField[] Field
        {
            get
            {
                return this.fieldField;
            }
            set
            {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PropertiesHierarchyType
        {
            get
            {
                return this.propertiesHierarchyTypeField;
            }
            set
            {
                this.propertiesHierarchyTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool AddSkippedProperties
        {
            get
            {
                return this.addSkippedPropertiesField;
            }
            set
            {
                this.addSkippedPropertiesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AddSkippedPropertiesSpecified
        {
            get
            {
                return this.addSkippedPropertiesFieldSpecified;
            }
            set
            {
                this.addSkippedPropertiesFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class PostObject_Settings
    {
        
        private ValueStruct additionalPropertiesField;
        
        private string documentWriteModeField;
        
        private string documentPostingModeField;
        
        private bool exchangeLoadModeField;
        
        private bool exchangeLoadModeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=0)]
        public ValueStruct AdditionalProperties
        {
            get
            {
                return this.additionalPropertiesField;
            }
            set
            {
                this.additionalPropertiesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DocumentWriteMode
        {
            get
            {
                return this.documentWriteModeField;
            }
            set
            {
                this.documentWriteModeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DocumentPostingMode
        {
            get
            {
                return this.documentPostingModeField;
            }
            set
            {
                this.documentPostingModeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool ExchangeLoadMode
        {
            get
            {
                return this.exchangeLoadModeField;
            }
            set
            {
                this.exchangeLoadModeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExchangeLoadModeSpecified
        {
            get
            {
                return this.exchangeLoadModeFieldSpecified;
            }
            set
            {
                this.exchangeLoadModeFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueStruct : ValueStructured
    {
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueStruct))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueRef))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueObjectRef))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueEnumRef))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public abstract partial class ValueStructured : ValueBase
    {
        
        private ValueBase[] propertyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Property", Order=0)]
        public ValueBase[] Property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueObjectRef))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueEnumRef))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public abstract partial class ValueRef : ValueStructured
    {
        
        private string typeField;
        
        private string presentationField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Presentation
        {
            get
            {
                return this.presentationField;
            }
            set
            {
                this.presentationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueObjectRef : ValueRef
    {
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueEnumRef : ValueRef
    {
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class RequestFieldAutoinclusionSettings
    {
        
        private bool defaultFieldsField;
        
        private bool defaultFieldsFieldSpecified;
        
        private bool customFieldsField;
        
        private bool customFieldsFieldSpecified;
        
        private bool tablesField;
        
        private bool tablesFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool DefaultFields
        {
            get
            {
                return this.defaultFieldsField;
            }
            set
            {
                this.defaultFieldsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DefaultFieldsSpecified
        {
            get
            {
                return this.defaultFieldsFieldSpecified;
            }
            set
            {
                this.defaultFieldsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool CustomFields
        {
            get
            {
                return this.customFieldsField;
            }
            set
            {
                this.customFieldsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CustomFieldsSpecified
        {
            get
            {
                return this.customFieldsFieldSpecified;
            }
            set
            {
                this.customFieldsFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Tables
        {
            get
            {
                return this.tablesField;
            }
            set
            {
                this.tablesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TablesSpecified
        {
            get
            {
                return this.tablesFieldSpecified;
            }
            set
            {
                this.tablesFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(GetObjectList_Settings))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class GetObject_Settings
    {
        
        private RequestField[] fieldField;
        
        private RequestFieldAutoinclusionSettings fieldAutoinclusionField;
        
        private string propertiesHierarchyTypeField;
        
        private bool addSkippedPropertiesField;
        
        private bool addSkippedPropertiesFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Field", Order=0)]
        public RequestField[] Field
        {
            get
            {
                return this.fieldField;
            }
            set
            {
                this.fieldField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public RequestFieldAutoinclusionSettings FieldAutoinclusion
        {
            get
            {
                return this.fieldAutoinclusionField;
            }
            set
            {
                this.fieldAutoinclusionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PropertiesHierarchyType
        {
            get
            {
                return this.propertiesHierarchyTypeField;
            }
            set
            {
                this.propertiesHierarchyTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool AddSkippedProperties
        {
            get
            {
                return this.addSkippedPropertiesField;
            }
            set
            {
                this.addSkippedPropertiesField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AddSkippedPropertiesSpecified
        {
            get
            {
                return this.addSkippedPropertiesFieldSpecified;
            }
            set
            {
                this.addSkippedPropertiesFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class GetObjectList_Settings : GetObject_Settings
    {
        
        private RequestFilter[] filterField;
        
        private RequestSort[] sortField;
        
        private uint limitField;
        
        private bool limitFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Filter", Order=0)]
        public RequestFilter[] Filter
        {
            get
            {
                return this.filterField;
            }
            set
            {
                this.filterField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Sort", Order=1)]
        public RequestSort[] Sort
        {
            get
            {
                return this.sortField;
            }
            set
            {
                this.sortField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public uint Limit
        {
            get
            {
                return this.limitField;
            }
            set
            {
                this.limitField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool LimitSpecified
        {
            get
            {
                return this.limitFieldSpecified;
            }
            set
            {
                this.limitFieldSpecified = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MetadataTableSection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MetadataObject))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MetadataModule))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MetadataAttribute))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MetadataCollection))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(MetadataApplication))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public abstract partial class MetadataNode
    {
        
        private string nameField;
        
        private string fullNameField;
        
        private string titleField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FullName
        {
            get
            {
                return this.fullNameField;
            }
            set
            {
                this.fullNameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Title
        {
            get
            {
                return this.titleField;
            }
            set
            {
                this.titleField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class MetadataTableSection : MetadataNode
    {
        
        private MetadataAttribute[] attributeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Attribute", Order=0)]
        public MetadataAttribute[] Attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class MetadataAttribute : MetadataNode
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class MetadataObject : MetadataNode
    {
        
        private MetadataAttribute[] attributeField;
        
        private MetadataTableSection[] tableSectionField;
        
        private ValueStruct predefinedField;
        
        private string collectionTypeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Attribute", Order=0)]
        public MetadataAttribute[] Attribute
        {
            get
            {
                return this.attributeField;
            }
            set
            {
                this.attributeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TableSection", Order=1)]
        public MetadataTableSection[] TableSection
        {
            get
            {
                return this.tableSectionField;
            }
            set
            {
                this.tableSectionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public ValueStruct Predefined
        {
            get
            {
                return this.predefinedField;
            }
            set
            {
                this.predefinedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CollectionType
        {
            get
            {
                return this.collectionTypeField;
            }
            set
            {
                this.collectionTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class MetadataModule : MetadataNode
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class MetadataCollection : MetadataNode
    {
        
        private MetadataNode[] itemField;
        
        private int totalObjectsCountField;
        
        private int requestedObjectsCountField;
        
        private int packObjectsCountField;
        
        public MetadataCollection()
        {
            this.totalObjectsCountField = 0;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Item", Order=0)]
        public MetadataNode[] Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int TotalObjectsCount
        {
            get
            {
                return this.totalObjectsCountField;
            }
            set
            {
                this.totalObjectsCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int RequestedObjectsCount
        {
            get
            {
                return this.requestedObjectsCountField;
            }
            set
            {
                this.requestedObjectsCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int PackObjectsCount
        {
            get
            {
                return this.packObjectsCountField;
            }
            set
            {
                this.packObjectsCountField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class MetadataApplication : MetadataNode
    {
        
        private MetadataCollection[] collectionField;
        
        private int totalObjectsCountField;
        
        private int requestedObjectsCountField;
        
        private int packSizeField;
        
        private int packIndexField;
        
        public MetadataApplication()
        {
            this.totalObjectsCountField = 0;
            this.packSizeField = 0;
            this.packIndexField = 0;
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Collection", Order=0)]
        public MetadataCollection[] Collection
        {
            get
            {
                return this.collectionField;
            }
            set
            {
                this.collectionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int TotalObjectsCount
        {
            get
            {
                return this.totalObjectsCountField;
            }
            set
            {
                this.totalObjectsCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int RequestedObjectsCount
        {
            get
            {
                return this.requestedObjectsCountField;
            }
            set
            {
                this.requestedObjectsCountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int PackSize
        {
            get
            {
                return this.packSizeField;
            }
            set
            {
                this.packSizeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(0)]
        public int PackIndex
        {
            get
            {
                return this.packIndexField;
            }
            set
            {
                this.packIndexField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class BinaryDataQualifiers
    {
        
        private int lengthField;
        
        private string allowedLengthField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AllowedLength
        {
            get
            {
                return this.allowedLengthField;
            }
            set
            {
                this.allowedLengthField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class DateQualifiers
    {
        
        private string dateFractionsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DateFractions
        {
            get
            {
                return this.dateFractionsField;
            }
            set
            {
                this.dateFractionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class NumberQualifiers
    {
        
        private int digitsField;
        
        private int fractionDigitsField;
        
        private bool onlyPositiveField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Digits
        {
            get
            {
                return this.digitsField;
            }
            set
            {
                this.digitsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int FractionDigits
        {
            get
            {
                return this.fractionDigitsField;
            }
            set
            {
                this.fractionDigitsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool OnlyPositive
        {
            get
            {
                return this.onlyPositiveField;
            }
            set
            {
                this.onlyPositiveField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class StringQualifiers
    {
        
        private int lengthField;
        
        private string allowedLengthField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Length
        {
            get
            {
                return this.lengthField;
            }
            set
            {
                this.lengthField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AllowedLength
        {
            get
            {
                return this.allowedLengthField;
            }
            set
            {
                this.allowedLengthField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class DataTableRow
    {
        
        private ValueBase[] propertyField;
        
        private DataTableRow[] rowField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Property", Order=0)]
        public ValueBase[] Property
        {
            get
            {
                return this.propertyField;
            }
            set
            {
                this.propertyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Row", Order=1)]
        public DataTableRow[] Row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class DataTableColumn
    {
        
        private string nameField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueTypeDescription : ValueBase
    {
        
        private ValueType[] itemField;
        
        private StringQualifiers stringQualifiersField;
        
        private NumberQualifiers numberQualifiersField;
        
        private DateQualifiers dateQualifiersField;
        
        private BinaryDataQualifiers binaryDataQualifiersField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Item", Order=0)]
        public ValueType[] Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=1)]
        public StringQualifiers StringQualifiers
        {
            get
            {
                return this.stringQualifiersField;
            }
            set
            {
                this.stringQualifiersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=2)]
        public NumberQualifiers NumberQualifiers
        {
            get
            {
                return this.numberQualifiersField;
            }
            set
            {
                this.numberQualifiersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=3)]
        public DateQualifiers DateQualifiers
        {
            get
            {
                return this.dateQualifiersField;
            }
            set
            {
                this.dateQualifiersField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true, Order=4)]
        public BinaryDataQualifiers BinaryDataQualifiers
        {
            get
            {
                return this.binaryDataQualifiersField;
            }
            set
            {
                this.binaryDataQualifiersField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueType : ValueBase
    {
        
        private string valueField;
        
        private string namespaceField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Namespace
        {
            get
            {
                return this.namespaceField;
            }
            set
            {
                this.namespaceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueDocumentWriteMode))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueDocumentPostingMode))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueAccumulationRecordType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueAccountingRecordType))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueAccountType))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public abstract partial class ValueSystemEnum : ValueBase
    {
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueDocumentWriteMode : ValueSystemEnum
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueDocumentPostingMode : ValueSystemEnum
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueAccumulationRecordType : ValueSystemEnum
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueAccountingRecordType : ValueSystemEnum
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueAccountType : ValueSystemEnum
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueStorage : ValueBase
    {
        
        private ValueBase dataField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ValueBase Data
        {
            get
            {
                return this.dataField;
            }
            set
            {
                this.dataField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueString))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueNumber))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueDate))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueBoolean))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public abstract partial class ValueSimple : ValueBase
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueString : ValueSimple
    {
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueNumber : ValueSimple
    {
        
        private decimal valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public decimal Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueDate : ValueSimple
    {
        
        private System.DateTime valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueBoolean : ValueSimple
    {
        
        private bool valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValuePointInTime : ValueBase
    {
        
        private ValueObjectRef refField;
        
        private System.DateTime dateField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ValueObjectRef Ref
        {
            get
            {
                return this.refField;
            }
            set
            {
                this.refField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime Date
        {
            get
            {
                return this.dateField;
            }
            set
            {
                this.dateField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueNull : ValueBase
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueNonserializable : ValueBase
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueMap : ValueBase
    {
        
        private ValueKeyValue[] keyValueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("KeyValue", Order=0)]
        public ValueKeyValue[] KeyValue
        {
            get
            {
                return this.keyValueField;
            }
            set
            {
                this.keyValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueKeyValue : ValueBase
    {
        
        private ValueBase keyField;
        
        private ValueBase valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ValueBase Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=1)]
        public ValueBase Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueGuid : ValueBase
    {
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueTree))]
    [System.Xml.Serialization.XmlIncludeAttribute(typeof(ValueTable))]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public abstract partial class ValueDataSet : ValueBase
    {
        
        private DataTableColumn[] columnField;
        
        private DataTableRow[] rowField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Column", Order=0)]
        public DataTableColumn[] Column
        {
            get
            {
                return this.columnField;
            }
            set
            {
                this.columnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Row", Order=1)]
        public DataTableRow[] Row
        {
            get
            {
                return this.rowField;
            }
            set
            {
                this.rowField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueTree : ValueDataSet
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueTable : ValueDataSet
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueDBNull : ValueBase
    {
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueBoundary : ValueBase
    {
        
        private ValueBase valueField;
        
        private string typeField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order=0)]
        public ValueBase Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueBinaryData : ValueBase
    {
        
        private byte[] valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="base64Binary")]
        public byte[] Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="https://brom.itworks.group")]
    public partial class ValueArray : ValueBase
    {
        
        private ValueBase[] itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Item", Order=0)]
        public ValueBase[] Item
        {
            get
            {
                return this.itemField;
            }
            set
            {
                this.itemField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMetadata", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetMetadataRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string nodes;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<uint> pack_size;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<uint> pack_index;
        
        public GetMetadataRequest()
        {
        }
        
        public GetMetadataRequest(string nodes, System.Nullable<uint> pack_size, System.Nullable<uint> pack_index)
        {
            this.nodes = nodes;
            this.pack_size = pack_size;
            this.pack_index = pack_index;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetMetadataResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetMetadataResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.MetadataApplication @return;
        
        public GetMetadataResponse()
        {
        }
        
        public GetMetadataResponse(ITworks.Brom.SOAP.MetadataApplication @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetObject", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetObjectRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueRef reference;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.GetObject_Settings settings;
        
        public GetObjectRequest()
        {
        }
        
        public GetObjectRequest(ITworks.Brom.SOAP.ValueRef reference, ITworks.Brom.SOAP.GetObject_Settings settings)
        {
            this.reference = reference;
            this.settings = settings;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetObjectResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetObjectResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueRef @return;
        
        public GetObjectResponse()
        {
        }
        
        public GetObjectResponse(ITworks.Brom.SOAP.ValueRef @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PostObject", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class PostObjectRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueObjectRef @object;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.PostObject_Settings settings;
        
        public PostObjectRequest()
        {
        }
        
        public PostObjectRequest(ITworks.Brom.SOAP.ValueObjectRef @object, ITworks.Brom.SOAP.PostObject_Settings settings)
        {
            this.@object = @object;
            this.settings = settings;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="PostObjectResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class PostObjectResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueObjectRef @return;
        
        public PostObjectResponse()
        {
        }
        
        public PostObjectResponse(ITworks.Brom.SOAP.ValueObjectRef @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteObject", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class DeleteObjectRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueObjectRef @object;
        
        public DeleteObjectRequest()
        {
        }
        
        public DeleteObjectRequest(ITworks.Brom.SOAP.ValueObjectRef @object)
        {
            this.@object = @object;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="DeleteObjectResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class DeleteObjectResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> @return;
        
        public DeleteObjectResponse()
        {
        }
        
        public DeleteObjectResponse(System.Nullable<bool> @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetObjectList", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetObjectListRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public string type;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        public string name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.GetObjectList_Settings settings;
        
        public GetObjectListRequest()
        {
        }
        
        public GetObjectListRequest(string type, string name, ITworks.Brom.SOAP.GetObjectList_Settings settings)
        {
            this.type = type;
            this.name = name;
            this.settings = settings;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetObjectListResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetObjectListResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueArray @return;
        
        public GetObjectListResponse()
        {
        }
        
        public GetObjectListResponse(ITworks.Brom.SOAP.ValueArray @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetConstant", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetConstantRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public string name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.GetConstant_Settings settings;
        
        public GetConstantRequest()
        {
        }
        
        public GetConstantRequest(string name, ITworks.Brom.SOAP.GetConstant_Settings settings)
        {
            this.name = name;
            this.settings = settings;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetConstantResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetConstantResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueBase @return;
        
        public GetConstantResponse()
        {
        }
        
        public GetConstantResponse(ITworks.Brom.SOAP.ValueBase @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SetConstant", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class SetConstantRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public string name;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        public ITworks.Brom.SOAP.ValueBase value;
        
        public SetConstantRequest()
        {
        }
        
        public SetConstantRequest(string name, ITworks.Brom.SOAP.ValueBase value)
        {
            this.name = name;
            this.value = value;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="SetConstantResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class SetConstantResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public System.Nullable<bool> @return;
        
        public SetConstantResponse()
        {
        }
        
        public SetConstantResponse(System.Nullable<bool> @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetConstantList", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetConstantListRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.GetConstant_Settings settings;
        
        public GetConstantListRequest()
        {
        }
        
        public GetConstantListRequest(ITworks.Brom.SOAP.GetConstant_Settings settings)
        {
            this.settings = settings;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="GetConstantListResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class GetConstantListResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueStruct @return;
        
        public GetConstantListResponse()
        {
        }
        
        public GetConstantListResponse(ITworks.Brom.SOAP.ValueStruct @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteRequest", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class ExecuteRequestRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public string request;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.ExecuteRequest_Settings settings;
        
        public ExecuteRequestRequest()
        {
        }
        
        public ExecuteRequestRequest(string request, ITworks.Brom.SOAP.ExecuteRequest_Settings settings)
        {
            this.request = request;
            this.settings = settings;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteRequestResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class ExecuteRequestResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueDataSet @return;
        
        public ExecuteRequestResponse()
        {
        }
        
        public ExecuteRequestResponse(ITworks.Brom.SOAP.ValueDataSet @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteRequestBatch", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class ExecuteRequestBatchRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public string request;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.ExecuteRequest_Settings settings;
        
        public ExecuteRequestBatchRequest()
        {
        }
        
        public ExecuteRequestBatchRequest(string request, ITworks.Brom.SOAP.ExecuteRequest_Settings settings)
        {
            this.request = request;
            this.settings = settings;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteRequestBatchResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class ExecuteRequestBatchResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public ITworks.Brom.SOAP.ValueArray @return;
        
        public ExecuteRequestBatchResponse()
        {
        }
        
        public ExecuteRequestBatchResponse(ITworks.Brom.SOAP.ValueArray @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteMethod", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class ExecuteMethodRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string module;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        public string method;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=2)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.ValueArray @params;
        
        public ExecuteMethodRequest()
        {
        }
        
        public ExecuteMethodRequest(string module, string method, ITworks.Brom.SOAP.ValueArray @params)
        {
            this.module = module;
            this.method = method;
            this.@params = @params;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteMethodResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class ExecuteMethodResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.ValueBase @return;
        
        public ExecuteMethodResponse()
        {
        }
        
        public ExecuteMethodResponse(ITworks.Brom.SOAP.ValueBase @return)
        {
            this.@return = @return;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteCode", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class ExecuteCodeRequest
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        public string code;
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=1)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.ValueBase param;
        
        public ExecuteCodeRequest()
        {
        }
        
        public ExecuteCodeRequest(string code, ITworks.Brom.SOAP.ValueBase param)
        {
            this.code = code;
            this.param = param;
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
    [System.ServiceModel.MessageContractAttribute(WrapperName="ExecuteCodeResponse", WrapperNamespace="https://brom.itworks.group", IsWrapped=true)]
    public partial class ExecuteCodeResponse
    {
        
        [System.ServiceModel.MessageBodyMemberAttribute(Namespace="https://brom.itworks.group", Order=0)]
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public ITworks.Brom.SOAP.ValueBase @return;
        
        public ExecuteCodeResponse()
        {
        }
        
        public ExecuteCodeResponse(ITworks.Brom.SOAP.ValueBase @return)
        {
            this.@return = @return;
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public interface brom_apiPortTypeChannel : ITworks.Brom.SOAP.brom_apiPortType, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("dotnet-svcutil", "1.0.0.0")]
    public partial class brom_apiPortTypeClient : System.ServiceModel.ClientBase<ITworks.Brom.SOAP.brom_apiPortType>, ITworks.Brom.SOAP.brom_apiPortType
    {
        
    /// <summary>
    /// Реализуйте этот разделяемый метод для настройки конечной точки службы.
    /// </summary>
    /// <param name="serviceEndpoint">Настраиваемая конечная точка</param>
    /// <param name="clientCredentials">Учетные данные клиента.</param>
    static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public brom_apiPortTypeClient(EndpointConfiguration endpointConfiguration) : 
                base(brom_apiPortTypeClient.GetBindingForEndpoint(endpointConfiguration), brom_apiPortTypeClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public brom_apiPortTypeClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(brom_apiPortTypeClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public brom_apiPortTypeClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(brom_apiPortTypeClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public brom_apiPortTypeClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public System.Threading.Tasks.Task<string> DebugPingAsync()
        {
            return base.Channel.DebugPingAsync();
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.ValueBase> DebugEchoAsync(ITworks.Brom.SOAP.ValueBase param)
        {
            return base.Channel.DebugEchoAsync(param);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.ValueStruct> GetSystemInfoAsync()
        {
            return base.Channel.GetSystemInfoAsync();
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetMetadataResponse> ITworks.Brom.SOAP.brom_apiPortType.GetMetadataAsync(ITworks.Brom.SOAP.GetMetadataRequest request)
        {
            return base.Channel.GetMetadataAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetMetadataResponse> GetMetadataAsync(string nodes, System.Nullable<uint> pack_size, System.Nullable<uint> pack_index)
        {
            ITworks.Brom.SOAP.GetMetadataRequest inValue = new ITworks.Brom.SOAP.GetMetadataRequest();
            inValue.nodes = nodes;
            inValue.pack_size = pack_size;
            inValue.pack_index = pack_index;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).GetMetadataAsync(inValue);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.ValueMap> GetMetadaChildrenNamesAsync(string parents)
        {
            return base.Channel.GetMetadaChildrenNamesAsync(parents);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetObjectResponse> ITworks.Brom.SOAP.brom_apiPortType.GetObjectAsync(ITworks.Brom.SOAP.GetObjectRequest request)
        {
            return base.Channel.GetObjectAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetObjectResponse> GetObjectAsync(ITworks.Brom.SOAP.ValueRef reference, ITworks.Brom.SOAP.GetObject_Settings settings)
        {
            ITworks.Brom.SOAP.GetObjectRequest inValue = new ITworks.Brom.SOAP.GetObjectRequest();
            inValue.reference = reference;
            inValue.settings = settings;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).GetObjectAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.PostObjectResponse> ITworks.Brom.SOAP.brom_apiPortType.PostObjectAsync(ITworks.Brom.SOAP.PostObjectRequest request)
        {
            return base.Channel.PostObjectAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.PostObjectResponse> PostObjectAsync(ITworks.Brom.SOAP.ValueObjectRef @object, ITworks.Brom.SOAP.PostObject_Settings settings)
        {
            ITworks.Brom.SOAP.PostObjectRequest inValue = new ITworks.Brom.SOAP.PostObjectRequest();
            inValue.@object = @object;
            inValue.settings = settings;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).PostObjectAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.DeleteObjectResponse> ITworks.Brom.SOAP.brom_apiPortType.DeleteObjectAsync(ITworks.Brom.SOAP.DeleteObjectRequest request)
        {
            return base.Channel.DeleteObjectAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.DeleteObjectResponse> DeleteObjectAsync(ITworks.Brom.SOAP.ValueObjectRef @object)
        {
            ITworks.Brom.SOAP.DeleteObjectRequest inValue = new ITworks.Brom.SOAP.DeleteObjectRequest();
            inValue.@object = @object;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).DeleteObjectAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetObjectListResponse> ITworks.Brom.SOAP.brom_apiPortType.GetObjectListAsync(ITworks.Brom.SOAP.GetObjectListRequest request)
        {
            return base.Channel.GetObjectListAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetObjectListResponse> GetObjectListAsync(string type, string name, ITworks.Brom.SOAP.GetObjectList_Settings settings)
        {
            ITworks.Brom.SOAP.GetObjectListRequest inValue = new ITworks.Brom.SOAP.GetObjectListRequest();
            inValue.type = type;
            inValue.name = name;
            inValue.settings = settings;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).GetObjectListAsync(inValue);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.ValueBase> GetSessionParameterAsync(string name)
        {
            return base.Channel.GetSessionParameterAsync(name);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetConstantResponse> ITworks.Brom.SOAP.brom_apiPortType.GetConstantAsync(ITworks.Brom.SOAP.GetConstantRequest request)
        {
            return base.Channel.GetConstantAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetConstantResponse> GetConstantAsync(string name, ITworks.Brom.SOAP.GetConstant_Settings settings)
        {
            ITworks.Brom.SOAP.GetConstantRequest inValue = new ITworks.Brom.SOAP.GetConstantRequest();
            inValue.name = name;
            inValue.settings = settings;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).GetConstantAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.SetConstantResponse> ITworks.Brom.SOAP.brom_apiPortType.SetConstantAsync(ITworks.Brom.SOAP.SetConstantRequest request)
        {
            return base.Channel.SetConstantAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.SetConstantResponse> SetConstantAsync(string name, ITworks.Brom.SOAP.ValueBase value)
        {
            ITworks.Brom.SOAP.SetConstantRequest inValue = new ITworks.Brom.SOAP.SetConstantRequest();
            inValue.name = name;
            inValue.value = value;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).SetConstantAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetConstantListResponse> ITworks.Brom.SOAP.brom_apiPortType.GetConstantListAsync(ITworks.Brom.SOAP.GetConstantListRequest request)
        {
            return base.Channel.GetConstantListAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.GetConstantListResponse> GetConstantListAsync(ITworks.Brom.SOAP.GetConstant_Settings settings)
        {
            ITworks.Brom.SOAP.GetConstantListRequest inValue = new ITworks.Brom.SOAP.GetConstantListRequest();
            inValue.settings = settings;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).GetConstantListAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteRequestResponse> ITworks.Brom.SOAP.brom_apiPortType.ExecuteRequestAsync(ITworks.Brom.SOAP.ExecuteRequestRequest request)
        {
            return base.Channel.ExecuteRequestAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteRequestResponse> ExecuteRequestAsync(string request, ITworks.Brom.SOAP.ExecuteRequest_Settings settings)
        {
            ITworks.Brom.SOAP.ExecuteRequestRequest inValue = new ITworks.Brom.SOAP.ExecuteRequestRequest();
            inValue.request = request;
            inValue.settings = settings;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).ExecuteRequestAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteRequestBatchResponse> ITworks.Brom.SOAP.brom_apiPortType.ExecuteRequestBatchAsync(ITworks.Brom.SOAP.ExecuteRequestBatchRequest request)
        {
            return base.Channel.ExecuteRequestBatchAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteRequestBatchResponse> ExecuteRequestBatchAsync(string request, ITworks.Brom.SOAP.ExecuteRequest_Settings settings)
        {
            ITworks.Brom.SOAP.ExecuteRequestBatchRequest inValue = new ITworks.Brom.SOAP.ExecuteRequestBatchRequest();
            inValue.request = request;
            inValue.settings = settings;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).ExecuteRequestBatchAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteMethodResponse> ITworks.Brom.SOAP.brom_apiPortType.ExecuteMethodAsync(ITworks.Brom.SOAP.ExecuteMethodRequest request)
        {
            return base.Channel.ExecuteMethodAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteMethodResponse> ExecuteMethodAsync(string module, string method, ITworks.Brom.SOAP.ValueArray @params)
        {
            ITworks.Brom.SOAP.ExecuteMethodRequest inValue = new ITworks.Brom.SOAP.ExecuteMethodRequest();
            inValue.module = module;
            inValue.method = method;
            inValue.@params = @params;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).ExecuteMethodAsync(inValue);
        }
        
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)]
        System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteCodeResponse> ITworks.Brom.SOAP.brom_apiPortType.ExecuteCodeAsync(ITworks.Brom.SOAP.ExecuteCodeRequest request)
        {
            return base.Channel.ExecuteCodeAsync(request);
        }
        
        public System.Threading.Tasks.Task<ITworks.Brom.SOAP.ExecuteCodeResponse> ExecuteCodeAsync(string code, ITworks.Brom.SOAP.ValueBase param)
        {
            ITworks.Brom.SOAP.ExecuteCodeRequest inValue = new ITworks.Brom.SOAP.ExecuteCodeRequest();
            inValue.code = code;
            inValue.param = param;
            return ((ITworks.Brom.SOAP.brom_apiPortType)(this)).ExecuteCodeAsync(inValue);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.brom_apiSoap))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            if ((endpointConfiguration == EndpointConfiguration.brom_apiSoap12))
            {
                System.ServiceModel.Channels.CustomBinding result = new System.ServiceModel.Channels.CustomBinding();
                System.ServiceModel.Channels.TextMessageEncodingBindingElement textBindingElement = new System.ServiceModel.Channels.TextMessageEncodingBindingElement();
                textBindingElement.MessageVersion = System.ServiceModel.Channels.MessageVersion.CreateVersion(System.ServiceModel.EnvelopeVersion.Soap12, System.ServiceModel.Channels.AddressingVersion.None);
                result.Elements.Add(textBindingElement);
                System.ServiceModel.Channels.HttpTransportBindingElement httpBindingElement = new System.ServiceModel.Channels.HttpTransportBindingElement();
                httpBindingElement.AllowCookies = true;
                httpBindingElement.MaxBufferSize = int.MaxValue;
                httpBindingElement.MaxReceivedMessageSize = int.MaxValue;
                result.Elements.Add(httpBindingElement);
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.brom_apiSoap))
            {
                return new System.ServiceModel.EndpointAddress("http://136.243.67.133/brom_ut/ws/brom_api");
            }
            if ((endpointConfiguration == EndpointConfiguration.brom_apiSoap12))
            {
                return new System.ServiceModel.EndpointAddress("http://136.243.67.133/brom_ut/ws/brom_api");
            }
            throw new System.InvalidOperationException(string.Format("Не удалось найти конечную точку с именем \"{0}\".", endpointConfiguration));
        }
        
        public enum EndpointConfiguration
        {
            
            brom_apiSoap,
            
            brom_apiSoap12,
        }
    }
}
