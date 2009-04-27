#Fibonacci series
def fib_to( max )
	i1 = 1
	i2 = 1
	while( i1 < max )
		yield i1
		i1,i2 = i2,i1 + i2
	end
end