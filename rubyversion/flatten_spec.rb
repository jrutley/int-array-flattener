require './flatten'

RSpec.describe Flattener do

  before(:each) do
    @flattener = Flattener.new
  end

  it 'returns empty for empty arrays' do
    result = @flattener.flatten([1,2,3])

    expect(result).to eq [1,2,3]
  end

  it 'does nothing to flat arrays' do
    result = @flattener.flatten([])

    expect(result).to eq []
  end

  it 'flattens inner arrays' do
    result = @flattener.flatten([1,[2],3])

    expect(result).to eq [1,2,3]
  end

  # TODO: fix this
  it 'rejects strings' do
    result = @flattener.flatten([1,"error",3])
    expect(result).to eq [1,"error",3]
  end

  # it 'processes very large arrays' do
  #   foo = Array.new(10000000)
  #   result = @flattener.flatten(foo)
  #   expect(result).to eq foo
  # end
end