using Microsoft.AspNetCore.Mvc;

namespace SimpleSystem.Server;

[Route("api/[controller]")]
[ApiController]
public class DiagramController : ControllerBase
{
    private readonly IDiagramService _diagramService;

    public DiagramController(IDiagramService diagramService)
    {
        _diagramService = diagramService;
    }

    [HttpPost("nodes")]
    public async Task<ActionResult<NodeDto>> CreateNode(CreateNodeDto createNodeDto)
    {
        var node = await _diagramService.CreateNodeAsync(createNodeDto);
        return Ok(node);
    }

    [HttpPut("nodes/{nodeId}")]
    public async Task<ActionResult<NodeDto>> MoveNode(string nodeId, MoveNodeDto moveNodeDto)
    {
        if (!string.Equals(nodeId, moveNodeDto.NodeId, StringComparison.Ordinal))
        {
            return BadRequest("Route node id must match the payload node id.");
        }

        var node = await _diagramService.MoveNodeAsync(moveNodeDto);
        if (node == null)
        {
            return NotFound("Node not found.");
        }

        return Ok(node);
    }

    [HttpDelete("nodes/{nodeId}")]
    public async Task<IActionResult> DeleteNode(string nodeId)
    {
        var deleted = await _diagramService.DeleteNodeAsync(nodeId);
        if (!deleted)
        {
            return NotFound("Node not found.");
        }

        return NoContent();
    }

    [HttpPost("edges")]
    public async Task<ActionResult<EdgeDto>> CreateEdge(CreateEdgeDto createEdgeDto)
    {
        var edge = await _diagramService.CreateEdgeAsync(createEdgeDto);
        return Ok(edge);
    }

    [HttpDelete("edges/{id:int}")]
    public async Task<IActionResult> DeleteEdge(int id)
    {
        var deleted = await _diagramService.DeleteEdgeAsync(id);
        if (!deleted)
        {
            return NotFound("Edge not found.");
        }

        return NoContent();
    }
}
