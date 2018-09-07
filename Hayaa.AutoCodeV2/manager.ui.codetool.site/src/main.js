// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import AppFrame from './AppFrame.vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import router from './router'
import webstore from './webstore'
import httphelper from './util/httphelper'


Vue.use(ElementUI)

Vue.config.productionTip = false
var appFrame=null;
 httphelper.post(webstore.configUrl, {"sid":"4b897adb-54b9-4203-9d59-286b2570396a","v":1}, function (configData) {
   webstore.urls=eval(configData);
   appFrame=new Vue({
     el: '#app',
     router,
     render: h => h(AppFrame)
   })
});



