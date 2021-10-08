import Vue from 'vue'
import App from './App.vue'
import { installComponents } from './'

Vue.config.productionTip = false

installComponents(Vue)
new Vue({
  render: (h) => h(App),
}).$mount('#app')
