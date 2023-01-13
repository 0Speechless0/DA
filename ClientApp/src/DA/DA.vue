<template>
    <div>
        <DATemplate 
            :DATitle="this.routeContent.DATitle" 
            :DAUnit="this.routeContent.DAUnit" 
            :route='this.index' 
            :hasBigCategorySelect="this.routeContent.hasBigCategorySelect"
            :anonyName="this.routeContent.anonyName"></DATemplate>
    </div>
</template>

<script>

import DATemplate from './DATemplate.vue';

export default {
    components : {
        DATemplate
    },
    data :() => {
        return  {
            index : 0,
            routeContent : {
                DATitle : null,
                DAUnit : null
            }

        }
    },
    methods :{
        routeSwitch(index) {
            switch(index) {
                case 0 : 
                    return {
                        DATitle : "職能",
                        DAUnit : "開課數"
                    }
                case 1 :
                    return {
                        DATitle : "學員",
                        DAUnit : "上課數",
                        anonyName : true
                    }
                case 3 : 
                    return {
                        DATitle : "推薦課程",
                        DAUnit : "上課時數",
                        hasBigCategorySelect : true
                    }
            }
        }
    },
    mounted() {
        let path_div = window.location.pathname.split('/')
        this.index = parseInt ( path_div[path_div.length - 1] );
        this.index = isNaN(this.index) ? 0 : this.index;
        this.routeContent = this.routeSwitch(this.index);
        console.log(this.index);
    }
}
 
</script>
