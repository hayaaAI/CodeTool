<template>
    <div>
        <div style="float: left">
            <h1 style="width:300px;float:left;margin-left:1%">
              HayaaAI-代码生成服务
            </h1>
        </div>
        <div style="float: right">
            <el-menu mode="horizontal" style="border: none">
                <el-menu-item index="1">{{userName}}</el-menu-item>
                <el-menu-item index="2"><router-link to="/home/message">消息中心({{messageTotal}})</router-link></el-menu-item>
                <el-menu-item index="3"><a @click="quit">退出</a></el-menu-item>
            </el-menu>

        </div>

    </div>
</template>

<script>
    export default {
        name: "NaviMenu",
        data:function(){
            return{
                userName:"匿名",
                messageTotal:0
            }
        },
        created:function(){
            this.getCurrentUser();
            this.getMessageTotal();
        },
        methods: {
            getCurrentUser:function(){

            },
            getMessageTotal:function(){

            },
            quit:function() {
            }
        }
    }
</script>

<style scoped>

</style>
