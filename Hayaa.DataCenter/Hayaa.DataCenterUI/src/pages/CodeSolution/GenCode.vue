<template>
    <div style="width: 600px;margin-left: 15%">
        <el-form :model="ruleForm" :rules="rules" ref="ruleForm" label-width="120px" class="demo-ruleForm">
            <el-form-item label="数据库连接" prop="databaseConnection">
                <el-input type="textarea" :rows="4"  v-model="ruleForm.databaseConnection"></el-input>
            </el-form-item>
            <el-form-item label="数据库" prop="databaseName">
                <el-input v-model="ruleForm.databaseName"></el-input>
            </el-form-item>
            <el-form-item label="数据表">
                <el-input v-model="tableName" style="width: 140px;"></el-input>
                <el-button type="primary" @click="addTable" size="small">添加表</el-button>
                <div>{{ruleForm.tables}}</div>
            </el-form-item>
            <el-form-item label="下载连接" v-show="isGen">
                <a :href="downUrl" target="_blank">下载代码点击</a>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="submitForm('ruleForm')">提交</el-button>
                <el-button @click="resetForm('ruleForm')">重置</el-button>
                <el-button @click="back">返回</el-button>
            </el-form-item>
        </el-form>

    </div>

</template>

<script>
    import httphelper from '../../util/httphelper'
    import urls from '../../urlstatic'

    export default {
        name: "GenCode",
        data: function () {
            return {
                isGen:false,
                downUrl:urls.codeGetFileUrl,
                tableName:"",
                ruleForm: {
                    solutionId:0,
                    databaseConnection: '',
                    databaseName: '',
                    tables: []
                },
                rules: {
                    databaseConnection: [
                        {required: true, message: '请输入数据库连接', trigger: 'blur'}
                    ],
                    databaseName: [
                        {required: true, message: '请输入数据库', trigger: 'blur'}
                    ]
                }
            };
        },
        created: function () {
            this.ruleForm.solutionId = this.$route.params.id;
        },
        methods: {
            back: function () {
                var that = this;
                this.$router.push("/home/codesolutionlist");
            },
            addTable:function(){
                this.ruleForm.tables.push(this.tableName);
                this.tableName="";
            },
            submitForm: function (formName) {
                var that = this;
                that.downUrl=urls.codeGetFileUrl;
                this.$refs[formName].validate(function (valid) {
                    if (valid) {
                        httphelper.authedpostform(urls.codeGenUrl, that.ruleForm,
                            function (data) {
                                that.isGen=true;
                                that.downUrl=that.downUrl+data.solutionPath;
                            });
                    } else {
                        return false;
                    }
                });
            },
            resetForm: function (formName) {
                this.ruleForm.tables=[];
                this.$refs[formName].resetFields();
            }
        }
    }
</script>

<style scoped>

</style>