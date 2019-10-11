/* 
 This source code (the "Generated Software") is generated by the OutSystems Platform 
 and is licensed by OutSystems (http://www.outsystems.com) to You solely for testing and evaluation 
 purposes, unless You and OutSystems have executed a specific agreement covering the use terms and 
 conditions of the Generated Software, in which case such agreement shall apply. 
*/


namespace OutSystems.ObjectKeys {

    public enum LocalKeyValue : ushort {

        None,

        // Keys for collections
        Entities,
        StaticEntities,
        Structures,
        UserExceptions,
        RoleExceptions,
        WebFlows,
        SMSFlows,
        UserActions,
        UserActionFolders,
        ClientActionFlows,
        ClientActionFlowFolders,
        SystemActions,
        SystemClientActions,
        SessionVariables,
        SiteProperties,
        Timers,
        Roles,
        SystemRoles,
        Images,
        Resources,
        ReferenceResources,
        ReferenceScripts,
        Scripts,
        ScriptDependencies,
        Locales,
        WebServices,
        WebReferences,
        References,
        RecordJoins,

        DataSets,
        Table,
        Sources,
        JoinConditions,
        CalculatedAttributes,
        Joins,
        Filters,
        Sorts,
        TableOperations,
        DetailsAttribute,
        GroupByAttributes,
        AggregateAttributes,
        AttributesInPreview,
        AttributeInPreview,

        //Key for AnonymousRecordTypes
        AnonymousStructures,
        RecordType,
        RecordListType,
        ListTypes,
        Records,
        MapExpression,
        EntityActions,
        IdentifierType,
        Attributes,
        EntityIndices,
        StaticRecords,
        CustomStaticRecords,
        ViewData,
        SampleRecord,
        AttributeValues,
        IndexAttributes,
        ReferenceProcesses,
        ReferenceWebFlows,
        ReferenceActions,
        ReferenceActionFolders,
        ReferenceClientActions,
        ReferenceClientActionFolders,
        ReferenceEntities,
        ReferenceStaticEntities,
        ReferenceStructures,
        ReferenceRoles,
        ReferenceImages,
        ReferenceExtensionContent,
        ReferenceActivities,
        ReferenceDataSets,
        WebReferenceMethods,
        WebReferenceStructures,
        WebServiceMethods,
        TimerActions,
        Arguments,
        RoleActions,
        LocalizedImages,
        NodesShownInESpaceTree,
        NodesNotShownInESpaceTree,
        InputParameters,
        LocalVariables,
        OutputParameters,
        ActivityOutputParameters,
        ReferenceWebBlocks,
        ReferenceWebScreens,
        Links,
        Preparation,
        OnSubmitAction,
        ScreenActions,
        Widgets,
        SMSPatterns,
        PatternTokens,
        QueryRecords,
        QueryParameters,
        QueryConditions,
        QueryOrderItems,
        OutputStructure,
        Conditions,
        Assignments,
        Permissions,
        ScreenExtendedProperties,
        ReferenceWidgets,
        ExtendedProperties,
        ValidRuntimeProperty,
        OnChange,
        Rows,
        ChildWidgets,
        OnClick,
        Branches,
        Cells,
        HeaderRow,
        DataRow,
        SpecialList,
        OnNotify,
        EventHandlers,
        BasicTypes,
        SystemExceptions,
        TextResources,
        Processes,
        ProcessActions,
        ProcessEntities,
        Flow,
        ActivityTasks,
        ActivityActions,
        ActivityCallbacks,
        ProcessCallbacks,
        SyntheticInputParameters,
        EventFilters,
        JavaScript,
        StyleSheet,
        InvisibleStyleSheet,
        EmbeddedResourceStyleSheet,
        AttributeSelection,
        EntityDiagrams,
        Imports,
        ExternalSchemas,
        UserScriptActions,
        BuiltinScriptActions,
        MetaEntities,
        Tutorials,
        TutorialBlocks,
        ContextualTutorials,
        Callback,
        SubTasks,
        TaskValidations,
        Items,
        Themes,
        ReferenceThemes,
        ReferenceStyleSheetImages,
        TestAttributeValues,
        TestCases,
        TestCaseFolders,
        TestStubs,
        ExpectedRecords,
        InteractionScript,
        AppliesTo,
        Setup,
        TearDown,
        CustomEvents,
        CustomEventHandlers,
        ReferenceParameters,
        ReferenceParameterArguments,
        PlaceholderArguments,
        CustomRuntimeProperties,
        OutSystemsJavascriptNamespacePositions,
        OutSystemsJQueryPositions,
        InlineDataSet,
        PreviewAttributes,
        GroupBy,
        OrderBy,
        CustomClients,
        CustomServices,
        CustomActions,
        CustomActionFlows,
        CustomCallbackFlows,
        CustomStructures,
        CustomEntities,
        CustomProperties,
        CustomObjectRuntimeProperties,
        ValueTypeConversion,
        AttributesMappings,
        TargetValue,
        SourceValue,
        ImplicitParameters,
        Fields,

        // Keys for expressions
        DefaultValue,
        OriginalDefaultValue,
        TestValue,
        Length,
        Decimals,
        Value,
        ValueExpression,
        Condition,
        InboxDetail,
        Variable,
        MaxRecords,
        Content,
        Filename,
        MimeType,
        From,
        To,
        CC,
        BCC,
        RecordList,
        StartIndex,
        LineCount,
        Maximum,
        RowNumber,
        File,
        SheetName,
        MSISDNList,
        ConfirmationMessage,
        Visible,
        Enabled,
        Mandatory,
        Display,
        SourceRecord,
        SourceRecordList,
        NullValue,
        SelectedValue,
        SpecialVariable,
        Label,
        URL,
        EntityIdentifier,
        Width,
        Height,
        Style,
        Animate,
        PhoneNumber,
        Timeout,
        TimeoutInstant,
        SLALimit,
        ValidationCondition,
        Originator,
        Recipient,
        Subject,
        ActivationInstant,
        InboxLabel,
        User,
        Group,
        Privilege,
        DueDate,
        ToolTip,
        Target,
        TargetX,
        TargetY,
        DragSourceTarget,
        DropTargetTarget,
        TextPosition,
        DragSourceTextPosition,
        DropTargetTextPosition,
        FolderName,
        DragSourceFolderName,
        DropTargetFolderName,
        CustomObjectKindName,
        DragSourceCustomObjectKindName,
        DropTargetX,
        DropTargetY,
        CustomLabel,
        PropertyValue,
        Prompt,
        Title,
        Obtained,
        EmptyMessage,
        OnRenderJavascript,
        EspaceConfigurations,
        ChildPlaceholders,
        OriginalAttribute,
        Steps,
        OperationPath,
        JSON,
        Field,

        // Keys for SQL expressions
        SQL,

        // Keys for signature elements
        CreateEntity,
        CreateOrUpdateEntity,
        CreateOrUpdateAllEntity,
        DeleteEntity,
        DeleteAllEntity,
        GetEntity,
        GetEntityForUpdate,
        UpdateEntity,

        CheckRole,
        GrantRole,
        RevokeRole,

        WakeTimer,

        LaunchProcess,
        StartActivity,
        CloseActivity,
        OnInitialize,
        OnReady,
        OnRender,
        OnParametersChanged,
        OnDestroy,
        OnOpen,
        OnStart,
        OnClose,
        OnSkip,
        OnProcessStart,
        OnActivityReady,
        OnActivityOpen,
        OnActivityStart,
        OnActivityClose,
        OnActivitySkip,

        Source,
        SourceList,
        ActivityId,
        ProcessId,
        EntityId,
        Id,
        Record,
        BillingDescription,
        BillingCode,
        Connection,
        Custom1,
        Custom2,
        Custom3,
        DlrStatus,
        LargeAccount,
        MessageId,
        OperatorCode,
        ResultCode,
        ResultDescription,
        Screen,
        SmsIn,
        SmsOut,
        CustomId,
        HasRole,
        UserId,
        MSISDN,

        OnDeliveryReport,
        OnMobileOriginatedMessage,
        OnMobileTerminatedMessage,
        OnSessionStart,
        OnBeginWebRequest,
        OnApplicationReady,
        OnApplicationResume,

        SMSMO,
        SMSMT,

        BinaryMessage,
        DeliveryReport,
        Encoding,
        MaximumParts,
        MClass,
        Message,
        OriginalMessageId,
        Pid,
        Priority,
        Sent,
        UDH,

        Name,
        NextHumanActivityId,
        Comment,

        // this is the synthesized Tenant_Id attribute of all multitenant entities with the ShowTenantId property set to true
        Tenant_Id,

        // this is the synthesized input for all the IEventConsumer flows that require a event input
        EventGeneratedInput,
        EventGeneratedOutput,

        // Extensions
        ExtensionResourceReferences,

        //the identifier attribute of all hidden reference entities 
        HiddenReferenceEntity_Id,

        //used for content only extensions
        ExtensionContent,

        //Synthesized collection used to represent the plugins that are in use on a eSpace
        PluginDescriptors,

        //New Runtime only
        DataModel,
        NRWebFlows,
        ReferenceNRWebFlows,
        ServerActions,
        ClientActions,
        NRThemes,
        NRReferenceThemes,
        ExceptionHandler,
        FlowExceptionHandler,
        JSInputParameters,
        JSOutputParameters,
        JavascriptSource,
        JsSource,
        ScreenDataSets,
        OnAfterFetch,
        ExtendedEvents,
        ViewRendererSharedDependencies,
        DataActions,
        PreviousScreen,
        CssSource,

        Sentinel,

        // Compiler-only Original Reference collections
        OriginalReferences,
        OriginalAnonymousStructures,
        OriginalListTypes,

        MetadataValue,
        Metadata,

        //Services
        ServiceAPIMethods,
        ReferenceServiceAPIMethods,

        Folders,
        ReferenceFolders,
    }
}