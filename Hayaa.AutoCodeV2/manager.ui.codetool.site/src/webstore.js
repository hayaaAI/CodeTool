const evn="test.";
var webstore={
  configUrl:"http://"+evn+"remoteconfig.xieqj.net/api/Config/SendJsAppConfig",
  baseUrl:{
    remoteconfig:"http://"+evn+"remoteconfig.xieqj.net/",
    security:"http://"+evn+"security.xieqj.net/",
    autocode:"http://"+evn+"code.xieqj.net/"
  },
  urls:null,
  sessionKey:new date().gettime(),
  authKey:""
};
export default webstore;
