﻿define("Extension.Text.model$TextRec", ["exports", "OutSystems/ClientRuntime/Main", "Extension.Text.model"], function (exports, OutSystems, Extension_TextModel) {
var OS = OutSystems.Internal;
var TextRec = (function (_super) {
__extends(TextRec, _super);
function TextRec(defaults) {
_super.apply(this, arguments);
}
TextRec.attributesToDeclare = function () {
return [
this.attr("Value", "valueAttr", "Value", true, false, OS.Types.Text, function () {
return "";
})
].concat(_super.attributesToDeclare.call(this));
};
TextRec.fromStructure = function (str) {
return new TextRec(new TextRec.RecordClass({
valueAttr: OS.DataTypes.ImmutableBase.getData(str)
}));
};
TextRec.init();
return TextRec;
})(OS.DataTypes.GenericRecord);
Extension_TextModel.TextRec = TextRec;

});
define("Extension.Text.model$TextRecord", ["exports", "OutSystems/ClientRuntime/Main", "Extension.Text.model", "Extension.Text.model$TextRec"], function (exports, OutSystems, Extension_TextModel) {
var OS = OutSystems.Internal;
var TextRecord = (function (_super) {
__extends(TextRecord, _super);
function TextRecord(defaults) {
_super.apply(this, arguments);
}
TextRecord.attributesToDeclare = function () {
return [
this.attr("Text", "textAttr", "Text", false, false, OS.Types.Record, function () {
return OS.DataTypes.ImmutableBase.getData(new Extension_TextModel.TextRec());
}, Extension_TextModel.TextRec)
].concat(_super.attributesToDeclare.call(this));
};
TextRecord.fromStructure = function (str) {
return new TextRecord(new TextRecord.RecordClass({
textAttr: OS.DataTypes.ImmutableBase.getData(str)
}));
};
TextRecord._isAnonymousRecord = true;
TextRecord.UniqueId = "0d84b59e-ff89-87c4-71ae-b49dfa9f2c39";
TextRecord.init();
return TextRecord;
})(OS.DataTypes.GenericRecord);
Extension_TextModel.TextRecord = TextRecord;

});
define("Extension.Text.model$TextRecordList", ["exports", "OutSystems/ClientRuntime/Main", "Extension.Text.model", "Extension.Text.model$TextRecord"], function (exports, OutSystems, Extension_TextModel) {
var OS = OutSystems.Internal;
var TextRecordList = (function (_super) {
__extends(TextRecordList, _super);
function TextRecordList(defaults) {
_super.apply(this, arguments);
}
TextRecordList.itemType = Extension_TextModel.TextRecord;
return TextRecordList;
})(OS.DataTypes.GenericRecordList);
Extension_TextModel.TextRecordList = TextRecordList;

});
define("Extension.Text.model", ["exports", "OutSystems/ClientRuntime/Main"], function (exports, OutSystems) {
var OS = OutSystems.Internal;
var Extension_TextModel = exports;
});
