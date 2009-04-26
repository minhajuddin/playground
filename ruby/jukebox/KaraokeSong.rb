class KaraokeSong <Song
	
	attr_reader :lyrics
	
	def initialize( name, artist, duration, lyrics )
		super( name, artist, duration )
		@lyrics = lyrics
	end
	
	def to_s
		#Bad way "Song: #{@name} -- #{@artist} (#{@duration}) [#{@lyrics}]"
		super + "[#{@lyrics}]"
	end
end