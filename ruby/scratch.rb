#Fibonacci series
def fib_to( max )
	i1 = 1
	i2 = 1
	while( i1 < max )
		yield i1
		i1,i2 = i2,i1 + i2
	end
end


def my_find( arr )
	arr.each do |x|
		x if yield(x)
	end
end
		
#code which returns a proc
def n_times( input )
	return lambda{|n| n * input}
end