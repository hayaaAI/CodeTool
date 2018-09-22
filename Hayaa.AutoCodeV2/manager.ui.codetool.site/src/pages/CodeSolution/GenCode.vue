<template>
  <div style="width: 600px;margin-left: 15%">
    <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="120px" class="demo-ruleForm">
      <el-form-item label="数据库连接列表">
        <el-select v-model="selecedCon" placeholder="请选择数据库连接" @change="getCon">
          <el-option
            v-for="item in conList"
            :key="item.title"
            :label="item.title"
            :value="item.dataConnectionId">
          </el-option>
        </el-select>
      </el-form-item>
      <el-form-item label="数据库连接" prop="databaseConnection">
        <el-input type="textarea" readonly="readonly" :rows="4" v-model="ruleForm.databaseConnection"></el-input>
      </el-form-item>
      <el-form-item label="数据库" prop="databaseName">
        <el-input readonly="readonly" v-model="ruleForm.databaseName"></el-input>
      </el-form-item>
      <el-form-item label="数据表">
        <el-input v-model="tableName" style="width: 140px;"></el-input>
        <el-button type="primary" @click="addTable" size="small">添加表</el-button>
        <div>{{ruleForm.tables}}</div>
      </el-form-item>
      <el-form-item label="下载连接" v-show="isGen">
        <a :href="downUrl" target="_blank">下载代码点击</a>
      </el-form-item>
      <el-form-item>
        <el-button type="primary" @click="submitForm('ruleForm')">提交</el-button>
        <el-button @click="resetForm('ruleForm')">重置</el-button>
        <el-button @click="back">返回</el-button>
      </el-form-item>
    </el-form>

  </div>

</template>

<script>
  import httphelper from '@/util/httphelper'
  import webstore from '@/webstore'

  export default {
    name: "GenCode",
    data: function () {
      return {
        conList: [],
        selecedCon: "",
        isGen: false,
        downUrl: webstore.urls.codeGetFileUrl,
        tableName: "",
        ruleForm: {
          solutionId: null,
          databaseConnection: '',
          databaseName: '',
          tables: []
        },
        conStrTmpl: "Data Source={databaseHost};Initial Catalog={databaseName};Persist Security Info=True;User ID={databaseUser};password={databaseToken};SslMode=none",
        rules: {}
      };
    },
    created: function () {
      this.ruleForm.solutionId = this.$route.params.id;
      this.getConList();
    },
    methods: {
      back: function () {
        var that = this;
        this.$router.push("/home/codesolutionlist");
      },
      getCon: function () {
        var that = this;

        for (var i = 0; i < that.conList.length; i++) {
          if (that.selecedCon == that.conList[i].dataConnectionId) {
            that.ruleForm.databaseConnection = that.conStrTmpl.replace("{databaseHost}", that.conList[i].databaseHost);
            that.ruleForm.databaseConnection = that.ruleForm.databaseConnection.replace("{databaseName}", that.conList[i].databaseName);
            that.ruleForm.databaseConnection = that.ruleForm.databaseConnection.replace("{databaseUser}", that.conList[i].databaseUser);
            that.ruleForm.databaseConnection = that.ruleForm.databaseConnection.replace("{databaseToken}", that.conList[i].databaseToken);
            that.ruleForm.databaseName=that.conList[i].databaseName;
            break;
          }
        }
      },
      getConList: function () {
        var that = this;
        httphelper.authedpostform(webstore.urls.dataConnectionGetListUrl, {"page": 1, "size": 300},
          function (data) {
            that.conList = data.data;
          });
      },
      addTable: function () {
        this.ruleForm.tables.push(this.tableName);
        this.tableName = "";
      },
      submitForm: function (formName) {
        var that = this;
        that.downUrl = webstore.urls.codeGetFileUrl;
        this.$refs[formName].validate(function (valid) {
          if (valid) {
            httphelper.authedpostform(webstore.urls.codeGenUrl, that.ruleForm,
              function (data) {
                that.isGen = true;
                that.downUrl = that.downUrl + data.solutionPath;
              });
          } else {
            return false;
          }
        });
      },
      resetForm: function (formName) {
        this.ruleForm.tables = [];
        this.$refs[formName].resetFields();
      }
    }
  }
</script>

<style scoped>

</style>
