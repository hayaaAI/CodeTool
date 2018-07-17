<template>
  <div>
    <router-view></router-view>
  </div>
</template>

<script>
  import httphelper from './util/httphelper'
  import urls from './urlstatic'

  export default {
    name: "AppFrame",
    data: function () {
      return {}
    },
    created: function () {
      this.auth()
    },
    methods: {
      auth: function () {
        var that = this;
        that.$router.push("/home");
        // httphelper.post(urls.authUrl, {}, function (islogin) {
        //   islogin = true;
        //   if (islogin) {
        //     that.$router.push("/home");
        //   } else {
        //     that.$router.push("/login");
        //   }
        // });
      }
    }
  }
</script>

<style scoped>

</style>
