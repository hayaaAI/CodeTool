// The Vue build version to load with the `import` command
// (runtime-only or standalone) has been set in webpack.base.conf with an alias.
import Vue from 'vue'
import AppFrame from './AppFrame.vue'
import ElementUI from 'element-ui'
import 'element-ui/lib/theme-chalk/index.css'
import router from './router'
import webstore from './webstore'


Vue.use(ElementUI)

Vue.config.productionTip = false

webstore.vueRouter=router;

var appFrame=new Vue({
  el: '#app',
  router,
  render: h => h(AppFrame)
});




