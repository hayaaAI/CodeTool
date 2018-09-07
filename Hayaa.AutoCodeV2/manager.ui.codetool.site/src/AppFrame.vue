<template>
  <div>
    <router-view></router-view>
  </div>
</template>

<script>
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
      }
    }
  }
</script>

<style scoped>

</style>
