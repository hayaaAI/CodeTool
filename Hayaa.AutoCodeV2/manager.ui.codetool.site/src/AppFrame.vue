<template>
  <div>
    <router-view></router-view>
  </div>
</template>

<script>
  import httphelper from './util/httphelper.js'
  import webstore from './webstore.js'
  import qs from 'qs'

  export default {
    name: "AppFrame",
    data: function () {
      return {}
    },
    created: function () {
      this.loader()
    },
    methods: {
      loader: function () {
        //console.log("loader")
        var that = this;
        httphelper.postform(webstore.configUrl, {
          "sid": "4b897adb-54b9-4203-9d59-286b2570396a",
          "v": 1
        }, function (configData) {
          webstore.urls = JSON.parse(configData);
          console.log(webstore.urls);
          for (var p in webstore.urls) {
            for (var a in webstore.baseUrl) {
              webstore.urls[p] = webstore.urls[p].replace("#"+a+"#", webstore.baseUrl[a]);
            }
          }
           console.log(webstore.urls);
          that.$router.push("/home");
        });

      }
    }
  }
</script>

<style scoped>

</style>
