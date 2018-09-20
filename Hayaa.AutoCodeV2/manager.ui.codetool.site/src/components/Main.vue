<template>
    <el-container>
        <el-header><navimenu></navimenu></el-header>
        <el-container>
            <el-aside width="240px"><leftment></leftment></el-aside>
            <el-container>
                <el-main><router-view></router-view></el-main>
                <el-footer>Footer</el-footer>
            </el-container>
        </el-container>
    </el-container>
</template>

<script>
    import LeftMenu from './LeftMenu.vue'
    import NaviMenu from './NaviMenu.vue'
    export default {
        name: "Main",
        created:function(){
            //this.$router.push("/home/index");
        },
        components:{
            "navimenu":NaviMenu,
            "leftment":LeftMenu
        }
    }
</script>

<style scoped>
     .el-footer {
        background-color: #B3C0D1;
        color: #333;
        text-align: center;
        line-height: 60px;
    }

    .el-aside {
        background-color: #D3DCE6;
        color: #333;
        text-align: center;
        line-height: 200px;
    }



    body > .el-container {
        margin-bottom: 40px;
    }

    .el-container:nth-child(5) .el-aside,
    .el-container:nth-child(6) .el-aside {
        line-height: 260px;
    }

    .el-container:nth-child(7) .el-aside {
        line-height: 320px;
    }
</style>