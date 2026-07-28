using System;
using AutoMapper;

namespace SimpleSystem.Server;

public class DiagramService : IDiagramService
{
    public readonly AppDbContext _context;
    public readonly IMapper _mapper;

    public DiagramService(AppDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;

    }

    public async Task<NodeDto> CreateNodeAsync(CreateNodeDto createNodeDto)
    {
        var node = _mapper.Map<Node>(createNodeDto);
        _context.Nodes.Add(node);
        await _context.SaveChangesAsync();
        return _mapper.Map<NodeDto>(node);

    }

    public async Task<NodeDto?> MoveNodeAsync(MoveNodeDto moveNodeDto, int id)
    {
        var node = await _context.Nodes.FindAsync(id);
        if (node == null)
        {
            return null;
        }
        _mapper.Map(moveNodeDto, node);
        await _context.SaveChangesAsync();
        return _mapper.Map<NodeDto>(node);
    }

    public async Task<bool> DeleteNodeAsync(int id) 
    {
        var node = await _context.Nodes.FindAsync(id);
        if (node == null)
        {
            return false;
        }
        _context.Nodes.Remove(node);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<EdgeDto> CreateEdgeAsync (CreateEdgeDto createEdgeDto)
    {
       var edge = _mapper.Map<Edge>(createEdgeDto);
        _context.Edges.Add(edge);
        await _context.SaveChangesAsync();
        return _mapper.Map<EdgeDto>(edge);

    }

    public async Task<bool> DeleteEdgeAsync(int id)
    {
        var edge = await _context.Edges.FindAsync(id);
        if (edge == null)
        {
            return false;
        }
        _context.Edges.Remove(edge);
        await _context.SaveChangesAsync();
        return true;
    }






}
