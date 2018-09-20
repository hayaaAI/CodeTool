<template>
  <el-container>
    <el-header>
      HayaaAI-代码生成服务
    </el-header>
    <el-main>
      <el-form ref="info" :model="info" :rules="rules" label-width="80px" style="width: 300px;margin-left: 30%">
        <el-form-item label="登录名">
          <el-input v-model="info.loginkey"></el-input>
        </el-form-item>
        <el-form-item label="密码">
          <el-input v-model="info.pwd" type="password"></el-input>
        </el-form-item>
        <el-form-item>
          <el-button type="primary" @click="login" style="width: 200px;">登陆</el-button>
        </el-form-item>
      </el-form>
    </el-main>
    <el-footer>Footer</el-footer>
  </el-container>

</template>

<script>
  import httphelper from '@/util/httphelper'
  import webstore from '@/webstore'

  export default {
    name: "Login",
    data: function () {
      return {
        info: {
          loginkey: "",
          pwd: ""
        },
        rules: {}
      }
    },
    methods: {
      login: function () {
        var that = this;
        httphelper.postform(webstore.urls.authUrl, {
            "loginkey": that.info.loginkey,
            "pwd": that.info.pwd,
            "sessionKey": webstore.sessionKey
          },
          function (loginKey) {
            if (loginKey) {
              webstore.setAuthKey(loginKey);
              that.$router.push("/home");
            }
          })
      }
    }
  }
</script>

<style scoped>
  .el-header {
    background-color: #B3C0D1;
    color: #333;
    text-align: center;
    line-height: 60px;
  }

  .el-footer {
    background-color: #B3C0D1;
    color: #333;
    text-align: center;
    line-height: 60px;
  }

  .el-aside {
    background-color: #D3DCE6;
    color: #333;
    text-align: center;
    line-height: 200px;
  }

  body > .el-container {
    margin-bottom: 40px;
  }

  .el-container:nth-child(5) .el-aside,
  .el-container:nth-child(6) .el-aside {
    line-height: 260px;
  }

  .el-container:nth-child(7) .el-aside {
    line-height: 320px;
  }
</style>
