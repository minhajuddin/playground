myVar = (function(){
	return {
	other:"This is the other value",
	init:function(){
		this.me=this;
	},
	test:function(){
	console.log(me.other);
	console.log(this.value);
	}	
}
}());

value = "Hello, World!";

//calling test using window as the context
test();

obj = {value:"Test"};
//calling test using obj as the context
test.call(obj);

myVar = (function(){
    return {
    	init:function(){
        this.x = this;
        console.log(this);
    }};
}());