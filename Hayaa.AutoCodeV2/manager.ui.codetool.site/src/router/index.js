import Vue from 'vue'
import Router from 'vue-router'
import Login from '@/components/Login.vue'
import Main from '@/components/Main.vue'
import Index from '@/pages/Index.vue'
import Message from '@/pages/Message.vue'
import CodeSolutionList from '@/pages/CodeSolution/CodeSolutionList.vue'
import GenCode from '@/pages/CodeSolution/GenCode.vue'
import CodeSolutionEdit from '@/pages/CodeSolution/CodeSolutionEdit.vue'
import CodeTemplateList from '@/pages/CodeTemplate/CodeTemplateList.vue'
import CodeTemplateEdit from '@/pages/CodeTemplate/CodeTemplateEdit.vue'
import DataConnectionList from '@/pages/DataConnection/DataConnectionList.vue'
import DataConnectionEdit from '@/pages/DataConnection/DataConnectionEdit.vue'

Vue.use(Router)

export default new Router({
  mode: 'history',
  routes: [
    {path: '/login', component: Login},
    {
      path: '/home',
      component: Main,
      children: [
        {path: "index", component: Index},
        {path: "message", component: Message},
        {path: "codesolutionlist", component: CodeSolutionList},
        {path: "codesolutionedit/:id?", component: CodeSolutionEdit},
        {path: "gencode/:id?", component: GenCode},
        {path: "codetemplatelist/:id", component: CodeTemplateList},
        {path: "codetemplateedit/:sid/:id?", component: CodeTemplateEdit},
        {path: "dataconnectionlist", component: DataConnectionList},
        {path: "dataconnectionedit/:id?", component: DataConnectionEdit}
      ]
    }
  ]
})
