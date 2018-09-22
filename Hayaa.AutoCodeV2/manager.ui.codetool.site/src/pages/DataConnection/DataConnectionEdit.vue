<template>
  <div style="width: 400px;margin-left: 15%">
    <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="100px" class="demo-ruleForm">
      <el-form-item label="名称" prop="name">
        <el-input v-model="ruleForm.name"></el-input>
      </el-form-item>
      <el-form-item label="可见名称" prop="title">
        <el-input v-model="ruleForm.title"></el-input>
      </el-form-item>
      <el-form-item label="数据库地址" prop="databaseHost">
        <el-input v-model="ruleForm.databaseHost"></el-input>
      </el-form-item>
      <el-form-item label="数据库名称" prop="databaseName">
        <el-input v-model="ruleForm.databaseName"></el-input>
      </el-form-item>
      <el-form-item label="登陆用户" prop="databaseUser">
        <el-input v-model="ruleForm.databaseUser"></el-input>
      </el-form-item>
      <el-form-item label="token" prop="databaseToken">
        <el-input v-model="ruleForm.databaseToken"></el-input>
      </el-form-item>
      <el-form-item label="备注" prop="remark">
        <el-input type="textarea" :rows="4"  v-model="ruleForm.remark"></el-input>
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
    name: "DataConnectionEdit",
    data: function () {
      return {
        ruleForm: {
          solutionTemplateId: 0,
          title: '',
          name: '',
          databaseHost: '',
          databaseName: '',
          databaseUser: '',
          databaseToken: '',
          remark: ''
        },
        rules: {
          name: [
            {required: true, message: '请输入名称', trigger: 'blur'},
            {min: 1, max: 50, message: '长度在 1 到 50 个字符', trigger: 'blur'}
          ],
          title: [
            {required: false, message: '请输入展示名称', trigger: 'blur'},
            {min: 1, max: 50, message: '长度在 1 到 50 个字符', trigger: 'blur'}
          ],
          databaseHost: [
            {required: true, message: '请输入数据库地址', trigger: 'blur'},
            {min: 1, max: 30, message: '长度在 1 到 30 个字符', trigger: 'blur'}
          ],
          databaseName: [
            {required: true, message: '请输入数据库名称', trigger: 'blur'},
            {min: 1, max: 300, message: '长度在 1 到 300 个字符', trigger: 'blur'}
          ],
          databaseUser: [
            {required: true, message: '请输入登陆用户', trigger: 'blur'},
            {min: 1, max: 100, message: '长度在 1 到 100 个字符', trigger: 'blur'}
          ],
          databaseToken: [
            {required: true, message: '请输入token', trigger: 'blur'},
            {min: 1, max: 1024, message: '长度在 1 到 1024 个字符', trigger: 'blur'}
          ]
        }
      };
    },
    created: function () {
      var id = this.$route.params.id;
      if (id > 0) {
        this.get(id);
      }
    },
    methods: {
      back: function () {
        this.$router.push("/home/dataconnectionlist");
      },
      get: function (id) {
        var that = this;
        httphelper.authedpostform(webstore.urls.dataConnectionGetUrl, {"id": id},
          function (data) {
            that.ruleForm = data;
          });
      },
      submitForm: function (formName) {
        var that = this;
        this.$refs[formName].validate(function (valid) {
          if (valid) {
            if (that.ruleForm.solutionTemplateId == 0) {
              httphelper.authedpostform(webstore.urls.dataConnectionAddUrl, that.ruleForm,
                function (data) {
                  that.back();
                });
            } else {
              httphelper.authedpostform(webstore.urls.dataConnectionEditUrl, that.ruleForm,
                function (data) {
                  if (data)
                    that.$notify.success("操作成功");
                });
            }
          } else {
            return false;
          }
        });
      },
      resetForm: function (formName) {
        this.$refs[formName].resetFields();
      }
    }
  }
</script>

<style scoped>

</style>
