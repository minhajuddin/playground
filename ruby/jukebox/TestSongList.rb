require 'test/unit'
class TestSongUnit < Test::Unit::TestCase
	def test_delete
		list = SongList.new
		s1 = Song.new( 'title1', 'artist1', 1 )
		s2 = Song.new( 'title2', 'artist1', 2 )
		s3 = Song.new( 'title3', 'artist3', 3 )
		s4 = Song.new( 'title4', 'artist4', 4 )
		list.append(s1).append(s2).append(s3).append(s4)
		
		#index assertions
		assert_equal(s1, list[0])
		assert_equal(s2, list[1])
		assert_equal(s3, list[2])
		assert_equal(s4, list[3])
		assert_nil(list[6])
		
		#delete_first, delete_last assertions
		assert_equal(s1, list.delete_first)
		assert_equal(s2, list.delete_first)
		assert_equal(s4, list.delete_last)
		assert_equal(s3, list.delete_last)
		assert_nil(list.delete_last)
		assert_nil(list.delete_first)
	end
end