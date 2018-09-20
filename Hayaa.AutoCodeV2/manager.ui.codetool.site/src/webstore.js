const evn="test.";
var webstore={
  configUrl:"http://"+evn+"remoteconfig.xieqj.net/api/Config/SendJsAppConfig",
  baseUrl:{
    remoteconfig:"http://"+evn+"remoteconfig.xieqj.net/",
    security:"http://"+evn+"security.xieqj.net/",
    autocode:"http://dev.code.xieqj.net:20001/"
  },
  urls:null,
  sessionKey:new Date().getTime(),
  authKey:"",
  vueRouter:null
};
export default webstore;
