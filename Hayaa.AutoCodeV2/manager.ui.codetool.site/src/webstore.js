const evn = "";
var webstore = {
  configUrl: "http://" + evn + "remoteconfig.xieqj.net/api/Config/SendJsAppConfig",
  baseUrl: {
    remoteconfig: "http://" + evn + "remoteconfig.xieqj.net/",
    security: "http://" + evn + "security.xieqj.net/",
    autocode: "http://" + evn + "mycode.xieqj.net/"
  },
  urls: null,
  sessionKey: new Date().getTime(),
  authkey: null,
  setAuthKey: function (authkey) {
    this.authkey =authkey;
    var d = new Date();
    d.setTime(d.getTime() + (24 * 60 * 60 * 1000));
    var expires = "expires=" + d.toUTCString();
    document.cookie = "hayaasession=" + authkey + "; " + expires;
    document.path="/";
  },
  getAuthKey: function () {
    if (this.authkey == null) {
      var name ="hayaasession=";
      var ca = document.cookie.split(';');
      for (var i = 0; i < ca.length; i++) {
        var c = ca[i];
        while (c.charAt(0) == ' ') c = c.substring(1);
        if (c.indexOf(name) != -1) {
          this.authkey=c.substring(name.length, c.length);
        }
      }
    }
    return this.authkey;
  },
  vueRouter: null
};
export default webstore;
