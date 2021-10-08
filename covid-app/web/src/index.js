import * as components from './components'

const installComponents = (Vue) => {
  Object.keys(components).forEach((key) => {
    let val = components[key]
    if (val.name && val.render) {
      Vue.component(val.name, val)
    }
  })
}

export { installComponents }
