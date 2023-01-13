module.exports = {
    outputDir: '../Content/dist',
    filenameHashing: false,

    publicPath: process.env.NODE_ENV == 'production' ? '/vue-template-primevue' : '/',
    configureWebpack: {
	devtool: 'source-map',
        optimization: {
            splitChunks: false
        },
        resolve: {
            alias: {
                'vue$': 'vue/dist/vue.esm.js'
            }
        },
    },
}
